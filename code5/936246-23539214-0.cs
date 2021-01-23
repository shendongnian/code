    public interface IFruit {}
    
    Apple : IFruit {...}
    
    Orange : IFruit {...}
    
    List<IFruit> list = new List<IFruit>();
    list.Add(new Apple());
    list.Add(new Orange());
