        public class Person
        {
            private Person() { }
            public int Age
            {
                get { return 10; }
            }
        }
    Now your instance cannot be created in such an easy way.
    First, you need to get your ConstructorInfo:
        ConstructorInfo c = typeof(Person).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] {  }, null);
    With the code above, your requesting information about the constructors which are not public (BindingFlags.NonPublic).
 
    After you have retrieved it, you can construct your object like:
        var instance = (Person)c.Invoke(new object[] { });
