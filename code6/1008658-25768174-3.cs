        public class Person
        {
            public int Age
            {
                get { return 10; }
            }
        }
    Your instance can be created like:
 
        var instance = (Person)Activator.CreateInstance(typeof(Person));
