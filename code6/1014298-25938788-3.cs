     public class X
     { 
        public int Value {get;set;}
        public X(int x)
        {
            this.Value = x;
        }
        public X Plus10()
        {
            Value += 10;
            return this;
        }
     }
    
    
     static void Main()
     {
         dynamic d = new DynamicIEnumerable<X>(Enumerable.Range(0, 10).Select(x => new X(x)));
         foreach (var res in d.Plus10().Plus10())
             Console.WriteLine(res.Value);
     }
