    class CustomerTypeDto
    {
        // string -> CustomerTypeDto
        public static explicit operator CustomerTypeDto(string s)
        {
            CustomerTypeDto ctd = new CustomerTypeDto();
            // ... do something with the string.
            return ctd;
        }
        // CustomerTypeDto -> string
        public static explicit operator String(CustomerTypeDto ctd)
        {
            return ctd.toString();
            // or some other way to return it's string value.
        }
        // other stuff...
    }
