    using System.IO;
    using System;
    
    public class SumObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
        public abstract class AbstractClass
        {
            protected SumObject SumProperty { get; private set; }
        
            protected AbstractClass()
            {
                SetupSumObjecInAbstractClass();
            }
        
            protected void SetupSumObjecInAbstractClass()
            {
                SumProperty = new SumObject() { ID = 1, Name = "James Dean" };
            }
        }
    
    
        public class ChildClass : AbstractClass
        {
            public ChildClass() : base()
            {
                 Console.WriteLine(string.Format("My Name is: {0}"
                                                , SumProperty.Name));
            }
        }
    
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            ChildClass c = new ChildClass();
        }
    }
