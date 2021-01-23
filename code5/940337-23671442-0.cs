    namespace Business
    {
        public class User
        {
            private int _id;
    
            public int ID
            {
                get { return _id; }
                set { 
                  if (value <= 0) 
                       throw new ArgumentOutOfRangeException(value, "value", "Impossible value");
    
                  _id = value; }
            }
        }
    }
