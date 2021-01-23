    public interface IPublic
    {
        ...
    }
    
    internal interface ISecret { }
    
    public class PublicImplementation : IPublic, ISecret
    {
        ...
    }
