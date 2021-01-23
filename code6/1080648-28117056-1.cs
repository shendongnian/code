    public bool UpdateSetting<T>(string key, T value)
    {
        lock 
        {
            T oldValue;            
            if (this.cachedValues.TryGetValue(key, out oldValue)
            {
                if (oldValue != value)
                {
                    this.cachedValues[key] = value;
                    settingRepository.Update(key, value);
                }
                return true;
            } 
            else 
            { 
               return false;
            }            
        }
    }
