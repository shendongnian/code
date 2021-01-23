        public static void ConversionTest()
        {
            var person = new Person { FirstName = "Bob", LastName = "Smith" };
            var validatable = (Validatable<Person>)person;           
            var cast = (Person)validatable; // FAILS here with InvalidCastException
        }
