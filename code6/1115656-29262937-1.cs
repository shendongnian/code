    public class WinFormsCode
    {
        private async Task WinsFormCodeBehindMethodAsync()
        {
            var updatesAvailable = await _updateManager.SearchForUpdatesAsync();
            MessageBox.Show("Updates Available: " + updatesAvailable.ToString());
        }
        private void WinsFormCodeBehindMethodSync()
        {
            var updatesAvailable = _updateManager.SearchForUpdatesAsync().Result;
            MessageBox.Show("Updates Available: " + updatesAvailable.ToString());
        }
    }
    public class UpdateManager
    {
        public async Task<bool> SearchForUpdatesAsync()
        {
            return true;
        }
    }
