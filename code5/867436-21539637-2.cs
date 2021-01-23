    #region Intellectuals
    public abstract IntellectualRightsBaseClass : EntityBaseClass, IIntellectualRights
    {
        ...
        public IReturnInvestment GetReturnInvestment()
        {
            return new IntellectualRightsInvestmentReturn(this);
        }
    }
    
    public class EngineDesignPatent : IntellectualRightsBaseClass
    {
        ...
        
    }
    
    public class BenzolMedicinePatent : IntellectualRightsBaseClass
    {
        ...
    }
    #endregion
    
    #region Retails
    public abstract RetailBusinessBaseClass : IRetailBusiness
    {
        ...
        public IReturnInvestment GetReturnInvestment()
        {
            return new RetailInvestmentReturn(this);
        }
    }
    
    public class BookShop : RetailBusinessBaseClass 
    {
        ...
    }
    
    public class AudioCDShop : RetailBusinessBaseClass 
    {
        ...
    }
    #endregion
