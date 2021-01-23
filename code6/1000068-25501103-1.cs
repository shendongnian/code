    public class User
    {
    
        //same as before
        
        public BillingStrategy BillingStrategy {get; set; }
        
        public User(string Name, Membership membership, BillingStrategy billingStrategy = null)
        {
        
            name = Name;
            MemberShip = memberShip;
            BillingStrategy = billingStrategy ? membership.DefaultBillingStrategy;
        
        }
    
    }
    enter code here
