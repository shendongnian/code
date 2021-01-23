        private Person ( String firstName, int age )
        {
            this.firstName = firstName;
            this.age = age;
        }
 
        public Person ( String firstName, String lastName, int age )
            :this(firstName, age)
        {
            this.lastName = lastName;
        }
