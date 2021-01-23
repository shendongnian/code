    internal sealed partial class Settings
    {
        private bool _isLoaded = false; 
        Dictionary<string, object> _tempValues = new Dictionary<string,object>();
        public override object this[string propertyName]
        {
            get
            {
                if (_isLoaded)
                {
                    return _tempValues[propertyName];
                }
                else
                {
                    return base[propertyName];
                }
            }
            set
            {
                if (_isLoaded)
                {
                    _tempValues[propertyName] = value;
                }
                else
                {
                    base[propertyName] = value;
                }
            }
        }
        protected override void OnSettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
            base.OnSettingsLoaded(sender, e);
            _isLoaded = true;
            foreach (SettingsProperty property in Properties)
            {
                _tempValues[property.Name] = base[property.Name];
            }
        }
        protected override void OnSettingsSaving(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (SettingsProperty property in Properties)
            {
                base[property.Name] = _tempValues[property.Name];
            }
            base.OnSettingsSaving(sender, e);
        }
    }
