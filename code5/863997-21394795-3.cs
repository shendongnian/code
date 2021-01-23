    public interface IMyService
    {
        Task SomeMethodAsync(Action<bool> callback);
    }
    public class MyServiceWrapper : IMyService
    {
        private IMyService _impl = null;
        private IMyService _remote, _local;
        private bool _loaded = false;
        private object _sync = new object();
        public Task SomeMethodAsync(Action<bool> callback)
        {
            // first make sure the settings have been loaded
            await LoadSettings();
            _impl.SomeMethodAsync(callback);
        }
        public MyServiceWrapper(MyRemoteService remoteService, MyLocalService localService)
        {
            _remote = remoteService;
            _local = localService;
            LoadSettings();
        }
        private async Task<bool> LoadSettings()
        {
            if (_loaded)
                return true;
            // lock to prevent multiple threads from loading the settings
            lock (_sync)
            {
                if (_loaded)
                    return true;
                if(await SettingsManager.LoadSettings().EnableRemote)
                    _impl = _remote;
                else
                    _impl = _local;
            }
            return true;
        }
    }
