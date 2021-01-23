        public class Person
        {
            public Person() { }
            public int Age
            {
                get { return 10; }
            }
        }
    Your instance can be created just in the same way as above, nothing special is needed.
 
        var instance = (Person)Activator.CreateInstance(typeof(Person));
