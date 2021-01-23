    public class AsyncTask : IAsyncTask
    {
        private ILifetimeScope _lifetimeScope;
        public AsyncTask(ILifetimeScope lifeTimeScope)
        {
            //disposed of by owning scope...
            _lifetimeScope = lifeTimeScope;
        }
        public async Task Fire<T>(Func<T,Task> asyncAction)
        {
            using (var scope = _lifetimeScope.BeginLifetimeScope())
            {
                await asyncAction(scope.Resolve<T>());
            }
        }
    }
    public interface IAsyncTask
    {
        Task Fire<T>(Func<T, Task> action);
    }
