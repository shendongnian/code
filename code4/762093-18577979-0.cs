    public class FinanceModel{
       public int MinimumCost {get;set;}
       
       [GreaterThan("MinimumCost")]
       public int MaximumCost {get;set;}
    }
