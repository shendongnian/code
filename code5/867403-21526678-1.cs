     public class InvestmentVisitor : IVisitor<InvestmentReturn>
     {
         public InvestmentReturn GetInvestment(IBusiness bus)
         {
              return bus.Accept(this);
         }
         public InvestmentReturn Visit(IIntellectualRights bus)
         {
              return new IntellectualRightsInvestmentReturn(bus)
         }
         
         public InvestmentReturn  Visit(IRetailBusiness bus)
         {
              return new RetailInvestmentReturn(bus);
         }
     }
