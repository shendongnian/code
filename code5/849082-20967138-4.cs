    public class StringArgs : EventArgs
    {
        private readonly string _txt;
        public string Txt
        {
            get { return this._txt; }
        }
    
        public StringArgs (string txt)
        {
            this._txt = txt;
        }   
    }
