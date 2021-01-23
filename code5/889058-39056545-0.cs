        public static string ReverseName( string theName)
        {
            string revName = string.Empty;
            foreach (char a in theName)
            {
                revName = a + revName;
            }
            return revName;
        }
