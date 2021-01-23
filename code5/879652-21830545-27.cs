    /// <summary>
    /// Factory. Provides a static method that initializes a new try-catch wrapper.
    /// </summary>
    public static class DangerousOperation
    {
        /// <summary>
        /// Starts a new try-catch block.
        /// </summary>
        /// <param name="action">The 'try' block's action.</param>
        /// <returns>Returns a new instance of the <see cref="TryCatchBlock"/> class that wraps the 'try' block.</returns>
        public static TryCatchBlock Try(Action action)
        {
            return new TryCatchBlock(action);
        }
    }
    /// <summary>
    /// Wraps a 'try' or 'finally' block.
    /// </summary>
    public class TryCatchBlock
    {
        private bool finalized;
        /// <summary>
        /// Initializes a new instance of the <see cref="TryCatchBlock"/> class;
        /// </summary>
        public TryCatchBlock()
        {
            this.First = this;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TryCatchBlock"/> class;
        /// </summary>
        /// <param name="action">The 'try' or 'finally' block's action.</param>
        public TryCatchBlock(Action action)
            : this()
        {
            this.Action = action;
        }
        protected TryCatchBlock(TryCatchBlock antecedent)
        {
            if ( antecedent == null )
            {
                throw new ArgumentNullException("antecedent");
            }
            if ( antecedent.finalized )
            {
                throw new InvalidOperationException("This block has been finalized with a call to 'Finally()'");
            }
            this.First = antecedent.First;
            this.Antecedent = antecedent;
            antecedent.Subsequent = this;
        }
        protected TryCatchBlock(TryCatchBlock antecedent, Action action)
            : this(antecedent)
        {
            this.Action = action;
        }
        public Action Action { get; set; }
        /// <summary>
        /// Gets the 'try' block.
        /// </summary>
        public TryCatchBlock First { get; private set; }
        /// <summary>
        /// Gets the next block.
        /// </summary>
        public TryCatchBlock Antecedent { get; private set; }
        /// <summary>
        /// Gets the previous block.
        /// </summary>
        public TryCatchBlock Subsequent { get; private set; }
        /// <summary>
        /// Creates a new 'catch' block and adds it to the chain.
        /// </summary>
        /// <returns>Returns a new instance of the <see cref="TryCatchBlock{TException}"/> class that wraps a 'catch' block.</returns>
        public TryCatchBlock<Exception> Catch()
        {
            return new TryCatchBlock<Exception>(this);
        }
        /// <summary>
        /// Creates a new 'catch' block and adds it to the chain.
        /// </summary>
        /// <returns>Returns a new instance of the <see cref="TryCatchBlock{TException}"/> class that wraps a 'catch' block.</returns>
        public TryCatchBlock<Exception> Catch(Action<Exception> action)
        {
            return new TryCatchBlock<Exception>(this, action);
        }
        /// <summary>
        /// Creates a new 'catch' block and adds it to the chain.
        /// </summary>
        /// <typeparam name="TException">The type of the exception that this block will catch.</typeparam>
        /// <returns>Returns a new instance of the <see cref="TryCatchBlock{TException}"/> class that wraps a 'catch' block.</returns>
        public TryCatchBlock<TException> Catch<TException>() where TException : System.Exception
        {
            return new TryCatchBlock<TException>(this);
        }
        /// <summary>
        /// Creates a new 'catch' block and adds it to the chain.
        /// </summary>
        /// <typeparam name="TException">The type of the exception that this block will catch.</typeparam>
        /// <param name="action">The 'catch' block's action.</param>
        /// <returns>Returns a new instance of the <see cref="TryCatchBlock{TException}"/> class that wraps a 'catch' block.</returns>
        public TryCatchBlock<TException> Catch<TException>(Action<TException> action) where TException : System.Exception
        {
            return new TryCatchBlock<TException>(this, action);
        }
        /// <summary>
        /// Creates a new 'finally' block and finalizes the chain.
        /// </summary>
        /// <param name="action">The 'finally' block's action.</param>
        /// <returns>Returns a new instance of the <see cref="TryCatchBlock"/> class that wraps the 'finally' block.</returns>
        public TryCatchBlock Finally(Action action)
        {
            return new TryCatchBlock(this, action) { finalized = true };
        }
        /// <summary>
        /// Gets a value indicating whether this 'catch' wrapper can handle and should handle the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Returns <c>True</c> if the exception can be handled; otherwise false.</returns>
        public virtual bool CanHandle(Exception exception)
        {
            return false;
        }
        /// <summary>
        /// Handles the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public virtual void Handle(Exception exception)
        {
            throw new InvalidOperationException("This is not a 'catch' block wrapper.");
        }
        /// <summary>
        /// Executes the chain of 'try-catch' wrappers.
        /// </summary>
        [DebuggerStepThrough]
        public void Execute()
        {
            TryCatchBlock current = this.First;
            try
            {
                current.Action();
            }
            catch ( Exception exception )
            {
                while ( current.Subsequent != null )
                {
                    current = current.Subsequent;
                    if ( current.CanHandle(exception) )
                    {
                        current.Handle(exception);
                        break;
                    }
                    if ( current.Subsequent == null )
                    {
                        throw;
                    }
                }
            }
            finally
            {
                while ( current.Subsequent != null )
                {
                    current = current.Subsequent;
                    if ( current.finalized )
                    {
                        current.Action();
                    }
                }
            }
        }
    }
    /// <summary>
    /// Wraps a 'catch' block.
    /// </summary>
    /// <typeparam name="TException">The type of the exception that this block will catch.</typeparam>
    public class TryCatchBlock<TException> : TryCatchBlock where TException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TryCatchBlock{TException}"/> class;
        /// </summary>
        /// <param name="antecedent">The 'try' or 'catch' block that preceeds this 'catch' block.</param>
        public TryCatchBlock(TryCatchBlock antecedent)
            : base(antecedent) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="TryCatchBlock{TException}"/> class;
        /// </summary>
        /// <param name="antecedent">The 'try' or 'catch' block that preceeds this 'catch' block.</param>
        /// <param name="action">The 'catch' block's action.</param>
        public TryCatchBlock(TryCatchBlock antecedent, Action<TException> action)
            : base(antecedent)
        {
            this.Action = action;
        }
        /// <summary>
        /// Sets a predicate that determines whether this block should handle the exception.
        /// </summary>
        /// <param name="predicate">The method that defines a set of criteria.</param>
        /// <returns>Returns the current instance.</returns>
        public TryCatchBlock<TException> When(Predicate<TException> predicate)
        {
            this.Predicate = predicate;
            return this;
        }
        /// <summary>
        /// Gets a value indicating whether this 'catch' wrapper can handle and should handle the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Returns <c>True</c> if the exception can be handled; otherwise false.</returns>
        public override bool CanHandle(Exception exception)
        {
            if ( exception == null )
            {
                throw new ArgumentNullException("exception");
            }
            if ( !typeof(TException).IsAssignableFrom(exception.GetType()) )
            {
                return false;
            }
            if ( Predicate == null )
            {
                return true;
            }
            return Predicate((TException) exception);
        }
        /// <summary>
        /// Handles the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public override void Handle(Exception exception)
        {
            if ( this.Action != null )
            {
                this.Action((TException) exception);
            }
        }
        /// <summary>
        /// Gets the exception handler.
        /// </summary>
        public Action<TException> Action { get; private set; }
        /// <summary>
        /// Gets the predicate that determines whether this wrapper should handle the exception.
        /// </summary>
        public Predicate<TException> Predicate { get; private set; }
    }
