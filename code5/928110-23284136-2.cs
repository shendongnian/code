    public struct Player
    {
        public int ID;
        public string Username;
        public string Password;
        private PStruct.Character[] character;
        public PStruct.Character[] Character 
        {
            get 
            { 
                if (null == character) 
                    character = new PStruct.Character[2]; // works
                
                return character; 
            }
            set 
            { 
                character = value; 
            }
        }
    }
