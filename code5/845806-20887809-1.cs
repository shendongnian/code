        private static Random random = new Random();
        public static string RandomToken(int length, string characterSet = "abcdefghijklmnopqrstuvwxyzABCDDEFGHIJKLMNOPQRSTUVWXYZ")
        {
            var builder = new StringBuilder();
            while(builder.Length < length) 
            {
                builder.Append(characterSet.ToCharArray()[random.Next(characterSet.Length)]);
            }
            return builder.ToString();
        }
