    public interface IBusiness
    {
        IReturnInvestment GetReturnInvestment();
        double GetProfit();
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
    
