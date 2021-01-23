    #region Intellectuals
    public abstract IntellectualRightsBaseClass : EntityBaseClass, IIntellectualRights
    {
        ...
        public IReturnInvestment GetReturnInvestment()
        {
            return new IntellectualRightsInvestmentReturn(this);
        }
        public double GetProfit()
        {
            return this.Royalty;
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
        public double GetProfit()
        {
            return this.GrossRevenue;
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
