    class Car
    {
        private string registration = "Unknown";
    
        public string Registration
        {
            get
            {
                return registration;
            }
            set
            {
                validate_registration(value, True);
                // Setter for the Property.
                // Throws an Exception upon invalid value.
            }
        }
    }
