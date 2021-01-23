        public bool IsUpdatingPushEnabled
        {
            get { return _isUpdatingPushEnabled; }
            set { SetProperty(ref _isUpdatingPushEnabled, value); }
        }
        public bool IsPushEnabled
        {
            get { return _isPushEnabled; }
            set
            {
                if (!IsUpdatingPushEnabled)
                {
                    SetProperty(ref _isPushEnabled, value);
                    var t = SetPushAsync();
                }
            }
        }
        private async Task SetPushAsync()
        {
            IsUpdatingPushEnabled = true;
            try
            {
                var result = await _settingService.EnablePushAsync(IsPushEnabled);
                SetProperty(ref _isPushEnabled, result, "IsPushEnabled");
            }
            catch
            {
                //...
            }
            IsUpdatingPushEnabled = false;
        }
