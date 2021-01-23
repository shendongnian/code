    public class Global 
    {
        private static readonly Global instance = new Global();
        public static Global Instance
        {
            get
            {
                return instance;
            }
        }
        Global()
        {
		}
		public string myproperty
        {
            get;set;
        }
		}
