    public interface IType
    {} 
    public class Thing : IType
    {} 
    public class Thing2 : IType
    {} 
    List<IType> list = new List<IType>();
    list.Add(new Thing1());
    list.Add(new Thing1())
