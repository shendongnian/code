        private void AddKey(string key, string value)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary.Remove(key);
                Dictionary.Add(key, value);
            }
            else
            {
                Dictionary.Add(key, value);
            }
        }
