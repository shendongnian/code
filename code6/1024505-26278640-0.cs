    public class Country
    {
        ....
        public CurrentPresident President 
        { 
            get
            {
                if (_president == null)
                {
                    _president = new CurrentPresident();
                }
                return _president;
            } 
            //no setter as outside objects don't need to create them
        }
        ....
        private CurrentPresident _president
    }
