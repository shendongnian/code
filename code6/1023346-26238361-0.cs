    public RoledPerson{
        public string Person;
        public string Role;
        
        public RoledPerson(string input){
            string[] splitInput = input.Split(';');
            Person = splitInput[0];
            Role = splitInput[1];
        }
    }
