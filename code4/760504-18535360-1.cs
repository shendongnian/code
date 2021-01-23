    public class TABLESCR
    {
        private string _data;
        public TABLESCR(string data)
        {
            _data = data;
        }
        
        public static implicit operator TABLESCR(string s)
        {
            return new TABLESCR(s);
        }
        public string DUEDATES
        {
            get { return ... }
            set { // set the value in the _data string }
        }
    }
