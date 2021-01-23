    class MasterMindModel
    {
        private string createSecretKey(int keyLength, List<char> keyItems)
        {
            StringBuilder secretKey = new StringBuilder();
    
            for (int i = 0; i < keyLength; i++)
            {
                secretKey.Append(keyItems[_rnd.Next(keyItems.Count)]);
            }
    
            return secretKey.ToString();
        }
    
    
        private bool isValidKey(string key, int keyLength, List<char> keyItems)
        {
            if (key.Length != keyLength)
            {
                return false;
            }
    
            foreach (char c in key)
            {
                if (!keyItems.Contains(c))
                {
                    return false;
                }
            }
    
            return true;
        }
    
        public void SelfTest()
        {
            int keyLength = 4;
            List<char> keyItems = new List<char> { '1', '2', '3', '4', '5', '6', '7' };
                
            Debug.Assert(isValidKey(createSecretKey(keyLength, keyItems), keyLength, keyItems));
            Debug.Assert(isValidKey(createSecretKey(keyLength, keyItems), 3, keyItems) == false);
            Debug.Assert(isValidKey(createSecretKey(keyLength, keyItems), keyLength, new List<char> { '0', '8', '9' }) == false);
        }
    
        private static Random _rnd = new Random();
    }
