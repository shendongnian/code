    public struct Player
    {
        public int ID;
        public string Username;
        public string Password;
        private PStruct.Character[] _character;
        public PStruct.Character[] character 
        {
            get 
            { 
                if (null == _character) 
                    _character = new PStruct.Character[2]; // works
                
                return _character; 
            }
            set 
            { 
                _character = value; 
            }
        }
    }
