    public class classA
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set
            {
                if (_ID == null) _ID = value;
                else throw new InvalidOperationException();
            }
        }
    }
