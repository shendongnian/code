    using System;
    using System.Reactive.Concurrency;
    using System.Reactive.Disposables;
    
    namespace SchedulerExample
    {
        class MyScheduler : IScheduler
        {
            private readonly ConsoleColor _colour;
    
            public MyScheduler(ConsoleColor colour)
            {
                _colour = colour;
            }
    
            public IDisposable Schedule<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
            {
                return Execute(state, action);
            }
    
            private IDisposable Execute<TState>(TState state, Func<IScheduler, TState, IDisposable> action)
            {
                var tmp = Console.ForegroundColor;
                Console.ForegroundColor = _colour;
                action(this, state);
                Console.ForegroundColor = tmp;
                return Disposable.Empty;
            }
    
            public IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action)
            {
                throw new NotImplementedException();
            }
    
            public IDisposable Schedule<TState>(TState state, DateTimeOffset dueTime, Func<IScheduler, TState, IDisposable> action)
            {
                throw new NotImplementedException();
            }
    
            public DateTimeOffset Now
            {
                get { return DateTime.UtcNow; }
            }
        }
    }
