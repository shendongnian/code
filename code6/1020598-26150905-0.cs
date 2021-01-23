    public interface ISetup
    {
        void Run();
        int SomeProp { get; set; }
    }
    
    public class Setup : ISetup
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    
        public int SomeProp
        {
            get
            {
                return 2;
            }
            set
            {
                SomeProp = value;
            }
        }
    }
     public bool MyMethod<T>(T t) where T :  ISetup
     { 
          return t.SomeProp != 2;
     }
