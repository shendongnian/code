    // this gets resolved in DI, so the IFactory<T> part is abstracted away
    public interface IMyRestrictionFactory
    {
        MyRestriction Create();
    }
    public class MyRestrictionFactory : IFactory<MyRestriction>, IMyRestrictionFactory
    {
        public MyRestriction Create()
        {
            // args provided by factory constructor
            return new MyRestriction(arg1, arg2); 
        }
    }
