        public class Person
        {
            public Person(int age)
            {
                Age = age;
            }
            public readonly int Age;
        }
    The creation is still quite easy:
        var instance = (Person)Activator.CreateInstance(typeof(Person), 15);
    You just need to pass all your parameters in the same way as they are defined in your constructor.
