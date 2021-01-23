    public class Panel
    {
        #region Singleton Pattern
        public static Panel instance = new Panel();
        public static Panel Instance
        {
            get { return instance; }
        }
        private Panel()
        {
        }
        #endregion
        public void DoSomething()
        {
            HttpContext.Current.Response.Write("Everything is OK!");
        }
    }
