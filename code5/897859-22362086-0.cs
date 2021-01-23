    public class PersonViewModel
    {
        private Person _person;
    
        public string Name
        {
            get
            {
                return _person.Name
            }
            set
            {
                if(value == string.empty)
                   throw new ValidationException("Name cannot be empty");
                _person.Name = value;
            }
        }
    }
