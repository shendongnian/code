    class Program
    {
        static void Main(string[] args)
        {
            List<MyFirstClass> firstClasses = new List<MyFirstClass>();
            MyFirstClass obj1 = new MyFirstClass();
            MyFirstClass obj2 = new MyFirstClass();
            MyFirstClass obj3 = new MyFirstClass();
            MyFirstClass obj4 = new MyFirstClass();
            firstClasses.Add(obj1);
            firstClasses.Add(obj2);
            firstClasses.Add(obj3);
            firstClasses.Add(obj4);
            var secondClasses = new MyClassFactory().MapClass<MySecondClass, MyFirstClass>(firstClasses);
        }
    }
