    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace States
    {
        /// <summary>
        /// Execute a command while asynchronously watching to see that a series of state transitions (of an arbitrary type) will be executed, 
        /// </summary>
        /// <example>
        /// A single instance is enough for each type of transition.
        /// <code>
        /// this.Expectations = new ClassCommandStateProgression();
        /// </code>
        /// Invocations should not be interleaved, even though if the state progression does not proceed as expected, the object will be cleaned up.
        /// <code>
        /// if (await this._Expectations.CommandExpectedStatesAsync(command, {state predicates}) { ... }
        /// </code>
        /// It is simple to inform the instance of state changes.
        /// <code>
        /// this._Expectations.StateTransition(state);
        /// </code>
        /// </example>
        public class ClassCommandStateProgression<T> where T : class
        {
            // Pair a TaskCompletionSource with a predicate for its completion
            private struct ExpectedTask
            {
                public readonly TaskCompletionSource<bool> gTask;
                public readonly Predicate<T> gPredicate;
    
                public ExpectedTask(Predicate<T> predicate)
                {
                    this._Task = new TaskCompletionSource<bool>();
                    this._Predicate = predicate;
                }
            }
    
            private Queue<ExpectedTask> gQ = new Queue<ExpectedTask>();
            private bool gResult;
    
            // Debug logging
            private ILogger gLogger;
            private Func<T, string> gIdentifyState;
            private static int gNestingLevel;       // Track waiting
    
            /// <summary>
            /// No logging by default.
            /// </summary>
            public ClassCommandStateProgression()
            {
            }
    
            /// <summary>
            /// For debugging purposes, identify when the state changes.
            /// </summary>
            /// <param name="logger">The logger to use.</param>
            /// <param name="identifyState">A delegate to describe the state.</param>
            public ClassCommandStateProgression(ILogger logger, Func<T, string> identifyState)
            {
                this._Logger = logger;
                this._IdentifyState = identifyState;
            }
    
            /// <summary>
            /// Execute a command that should cause a series of asynchronous state transitions.
            /// </summary>
            /// <param name="command">The command to execute.</param>
            /// <param name="predicates">A list of predicates describing the expected states.</param>
            /// <returns>True if all state transitions took place as expected.</returns>
            public async Task<bool> CommandExpectedStatesAsync(Action command, params Predicate<T>[] predicates)
            {
                this._Result = true;
    
                if (null != predicates && predicates.Length > 0)
                {
                    foreach (var predicate in predicates)
                    {
                        this._Q.Enqueue(new ExpectedTask(predicate));
                    }
                }
    
                return await AwaitExpectedStatesAsync(command).ConfigureAwait(false);
            }
    
            /// <summary>
            /// Execute a command that should cause a series of asynchronous state transitions,
            /// perhaps being originally in the first of the states.
            /// </summary>
            /// <param name="state">The original state.</param>
            /// <param name="command">The command to execute.</param>
            /// <param name="predicates">A list of predicates describing the expected states.</param>
            /// <returns>True if all state transitions took place as expected.</returns>
            public async Task<bool> CommandExpectedStatesAsync(T state, Action command, params Predicate<T>[] predicates)
            {
                this._Result = true;
    
                if (null != predicates && predicates.Length > 0)
                {
                    bool alreadyInState = predicates[0](state);
                    foreach (var predicate in predicates)
                    {
                        if (alreadyInState)
                        {
                            if (null != this._Logger) { this._Logger.Debug("Already true => {0}", this._IdentifyState(state)); }
    
                            alreadyInState = false;
                            continue;
                        }
                        this._Q.Enqueue(new ExpectedTask(predicate));
                    }
                }
    
                return await AwaitExpectedStatesAsync(command).ConfigureAwait(false);
            }
    
            // Await the queued states.
            private async Task<bool> AwaitExpectedStatesAsync(Action command)
            {
                try
                {
                    if (null != this._Logger) { this._Logger.Debug("Waiting for {0} state transitions.", this._Q.Count); }
    
                    // The caller must catch any exceptions thrown by the command.
                    command();
    
                    while (this._Result && this._Q.Count > 0)
                    {
                        try
                        {
                            Interlocked.Increment(ref gNestingLevel);
                            if (null != this._Logger) { this._Logger.Debug("Awaiting managed thread {0}; at nesting {1}.", Thread.CurrentThread.ManagedThreadId, gNestingLevel); }
    
                            var waitFor = this._Q.Peek()._Task;
                            await waitFor.Task.ConfigureAwait(false);
                            this._Result = waitFor.Task.Result;
    
                            Interlocked.Decrement(ref gNestingLevel);
                            if (null != this._Logger) { this._Logger.Debug("Back from await; at nesting {0}.", gNestingLevel); }
                        }
                        catch (TaskCanceledException)
                        {
                            return false;
                        }
                    }
    
                    return this._Result;
                }
                finally
                {
                    this._Q.Clear();
                }
            }
    
            /// <summary>
            /// Transition to the next state.
            /// </summary>
            /// <param name="state">A state object of the parameterized type <typeparamref name="T"/>.</param>
            public void StateTransition(T state)
            {
                if (this._Q.Count > 0)
                {
                    ExpectedTask et = this._Q.Dequeue();
                    this._Result = this._Result && et._Predicate(state);
                    if (null != this._Logger)
                    {
                        if (!this._Result) { this._Logger.Warn("UNEXPECTED! => {0}", this._IdentifyState(state)); }
                        else { this._Logger.Debug("{0}{1}", this._IdentifyState(state), this._Q.Count > 0 ? ", still waiting..." : "."); }
                    }
                    et._Task.TrySetResult(this._Result);
                }
            }
    
            /// <summary>
            /// Stop waiting.
            /// </summary>
            public void Cancel()
            {
                if (this._Q.Count > 0) { this._Q.Peek()._Task.TrySetCanceled(); }
            }
        }
    }
