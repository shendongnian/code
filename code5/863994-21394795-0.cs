    public interface IMyService
    {
        void SomeMethodAsync(Action<bool> callback);
    }
    public class MyService : IMyService
    {
        private IMyService _impl;
        private readonly IMyService _remote, _local;
        public event EventHandler SettingsLoaded;
        public bool AreSettingsLoaded { get; set; }
        public void SomeMethodAsync(Action<bool> callback)
        {
            if (_impl == null) 
                throw new InvalidOperationException("Settings haven't been loaded yet!");
            _impl.SomeMethodAsync(callback);
        }
        public MyService(MyRemoteService remoteService, MyLocalService localService)
        {
            _remote = remoteService;
            _local= localService;
            LoadSettings();
        }
        private async void LoadSettings()
        {
            if(await SettingsManager.LoadSettings().EnableRemote)
            {
                _impl = _remote;
            }
            else
            {
                _impl = _local;
            }
            AreSettingsLoaded = true;
            if (SettingsLoaded != null)
                SettingsLoaded(this, EventArgs.Empty);
        }
    }
