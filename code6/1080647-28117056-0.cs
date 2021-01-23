    public bool UpdateSetting<T>(string key, T value)
    {
        lock 
        {
            try 
            {
                T oldValue = this.cachedValues[key];
                if (oldValue != value)
                {
                    this.cachedValues[key] = value;
                    settingRepository.Update(key, value);
                }
            } 
            catch (KeyNotFoundException ex) 
            { 
               return false;
            }
            return true;
        }
    }
