    public interface IMyService 
    { 
        Model GetModelData(int id)
    }
    
    public class MyService : IMyService
    {
        public virtual Model GetModelData(int id)
        { 
           //call to db     
        }
    }
    
    public class MyService2 : MyService
    {
        public MyService2()
            : base(new MyRepository())
        {    
        }
    
        public override Model GetModelData(int id)
        { 
            return new Model();
        }
    }
