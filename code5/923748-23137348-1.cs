    public class DoStuff : IDoStuff
    {
        public int StuffId { get; set; } //class property
    
        public DoStuff(int stuffId)
        {
          StuffId = stuffId;
        }
        //...
    }
