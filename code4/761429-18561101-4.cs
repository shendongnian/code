    // NOT REAL CODE
    public interface IMyInterface { } 
    public class MyRealClass : IMyInterface { } 
    ...
    public class Domain
    {
        private List<MyRealClass> myList;
        public IList<IMyInterface> Interfaces { get { return (IList<IMyInterface>)this.myList; } }
    }
