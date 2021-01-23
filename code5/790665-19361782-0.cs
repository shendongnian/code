    public static class GlobalVariables
    {
        private static string _data;
    
        public static string Data
        {
            get { return _data ?? "Invalid"; }
            set { _data = value; }
        }
    }
