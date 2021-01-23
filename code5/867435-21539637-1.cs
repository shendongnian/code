    public interface IBusiness
    {
        IReturnInvestment GetReturnInvestment();
    }
    
    public abstract class EntityBaseClass
    {
    
    }
    
    public interface IRetailBusiness : IBusiness
    {
        ...
    }
    
    public interface IIntellectualRights : IBusiness
    {
        ...
    }
    
