    public class MyVal 
    {
        public int id { get; set; }
        public double SomeVal { get; set; }
      
        public MyVal Clone(MyVal obj)
        {
            return new MyVal {id = obj.id, SomeVal = obj.SomeVal }
        }
    }
