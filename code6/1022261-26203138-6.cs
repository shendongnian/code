    class GlobalVariables : IGlobalVariables
    {
        private bool _appIsClosing = false;
        private static GlobalVariables _instance = new GlobalVariables();
        private GlobalVariables() {}
        public static Instance {
            get { return _instance }
        }
        public bool IGlobalVariables.AppIsClosing
        {
            get { return this._appIsClosing; }
            set { this._appIsClosing = value; }
        }
    }
