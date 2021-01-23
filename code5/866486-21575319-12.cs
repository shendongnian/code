    public interface IBusiness
    {
        InvestmentReturnCalculator GetMyInvestmentReturnCalculator();
    }
    public abstract class EntityBaseClass
    {
    }
    public interface IRetailBusiness : IBusiness
    {
        double GrossRevenue { get; set; }
    }
    public interface IIntellectualRights : IBusiness
    {
        double Royalty { get; set; }
    }
