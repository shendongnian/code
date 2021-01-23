    public class classA
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set
            {
                // This will always throw an exception
                if (_ID == null) 
                {
                    // Is this what you intended? 
                    // That is, throw an InvalidOperationException if a null value is supplied?
                    throw new InvalidOperationException();
                }
                _ID = value;
            }
        }
    }
