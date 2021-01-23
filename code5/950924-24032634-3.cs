    public class PolicyRepository
    {
       private MyContext context = new MyContext();
    
       public PolicyRepository()
       {
       }
       
       public IQueryable<InsurancePolicy> GetInsurancePolicies()
       {
          return this.context.Policies.OfType<InsurancePolicy>();
       }
    
       public IQueryable<CarPolicy> GetCarPolicies()
       {
          return this.context.Policies.OfType<CarPolicy>();
       }
    }
