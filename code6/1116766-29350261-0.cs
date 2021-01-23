    class CustomerTypeDto
    {
        public static explicit operator CustomerTypeDto(string s)
        {
            CustomerTypeDto ctd = new CustomerTypeDto();
            // ... do something with the string.
            return ctd;
        }
        // other stuff...
    }
