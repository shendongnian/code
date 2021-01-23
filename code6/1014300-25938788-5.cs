     public class SomeClass
     { 
        public int Value {get;set;}
        public SomeClass(int value)
        {
            this.Value = x;
        }
        public SomeClass Plus10()
        {
            Value += 10;
            return this;
        }
     }
    
    
     static void Main()
     {
         dynamic d = new DynamicIEnumerable<X>(Enumerable.Range(0, 10).Select(x => new SomeClass(x)));
         foreach (var res in d.Plus10().Plus10())
             Console.WriteLine(res.Value);
     }
