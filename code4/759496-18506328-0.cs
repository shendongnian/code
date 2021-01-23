    public abstract class Converter
    {
        private readonly MyData data;
        protected Converter(MyData data)    
        {
           this.data = data;
        }
        public MyData Data { get { return data; } }    
    }
      
    public class MyData
    {        
        private readonly int value;
        public MyData(int value)
        {
           this.value = value;
        }
    
        public int MyValue { get { return value; } }
    }
    public class Converter1 : Converter
    {
       public Converter1()
          : base(new MyData(5))
       {
       }
    }
