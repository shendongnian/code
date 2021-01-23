        public bool UpdateSetting<T>(string key, T value)
        {
            lock {
                try {
                    this.cachedValues[key] = value;
                    this.settingRepository.Update(... //you'll have to write this
                } catch (KeyNotFoundException ex) { 
                    return false;
                }
                return true;
            }
        }
