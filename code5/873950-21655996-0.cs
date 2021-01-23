        private RegistryKey SearchSubKey(RegistryKey Key,String KeyName)
        {
            foreach (String subKey in Key.GetSubKeyNames())
            {
                RegistryKey key1 = Key.OpenSubKey( subKey);
                if (subKey.ToUpper() == KeyName.ToUpper())
                    return key1;
                else
                {
                    RegistryKey mReturn = SearchSubKey(key1, KeyName);
                    if (mReturn != null)
                        return mReturn;
                }
            }
            return null;
        }
