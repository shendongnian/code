    class Animal { }
    class Cat : Animal { }
    class Dog : Animal
    {
        public override string ToString()
        {
            return "I'm a dog!";
        }
         public bool IsDog { get { return true; } }
    }
    Animal a = new Dog();
    var methodInfo = typeof (Converter)
                    .GetMethod("ConvertTo", BindingFlags.Static | BindingFlags.Public);
    var method = methodInfo.MakeGenericMethod(a.GetType());
    var dog = method.Invoke(null, new object[] { a });
    Console.WriteLine(dog.ToString());
