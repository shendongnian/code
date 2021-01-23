        public class Person
        {
            public Person(int age)
            {
                Age = age;
            }
            public readonly int Age;
        }
    Again, we'll need the ConstructorInfo object, but now we need to specify with types of parameters     are constructor is accepting. In the example above, this is an integer:
        ConstructorInfo c = typeof(Person).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(int) }, null);
    Now, you can create an object and as a last parameter you specify all the arguments to construct your object.
        var instance = (Person)c.Invoke(new object[] { 15 });
