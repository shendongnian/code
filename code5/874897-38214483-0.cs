        public Guid HostId
        {
            get
            {
                var result = GetSetting(ConfigFileLocalSettingList.HostId).TryToGuid();
                if (result == null)
                {
                    result = Guid.NewGuid();
                    SetSetting(ConfigFileLocalSettingList.HostId, result.ToString());
                    Save();
                }
                return result.Value;
            }
        }
