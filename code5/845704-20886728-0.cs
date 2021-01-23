    using System;
    using System.Reflection;
    
    namespace reflectionsAreCool
    {
        class foo
        {
            public string bar
            {
                get;
                set;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                foo Foo = new foo();
                Foo.bar = "Conan the Foobarian";
                // get property with given name, GetProperties will return all available properties
                PropertyInfo propertyInfo = Foo.GetType().GetProperty("bar");
                string value = "System.Reflection is cool!";
                //set desired value
                propertyInfo.SetValue(Foo, Convert.ChangeType(value, propertyInfo.PropertyType, null));
                Console.WriteLine(Foo.bar);
                Console.ReadLine();
            }
        }
    }
