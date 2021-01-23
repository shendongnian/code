    public class ClassA
        {
            public int id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public string note { get; set; }
        }
    
     public class ClassB
        {
            public int id { get; set; }
            public string name { get; set; }
            public int age { get; set; }
            public string note { get; set; }
            public int index { get; set; }
        }
    
    static void Main(string[] args)
            {
               //create an object with ClassA  type
                ClassA a = new ClassA { id=1,age=12,name="John",note="good"};
                ClassB b=a.Cast<ClassB>();
            }
