    public class Membership
    {
    
        public String Name { get; private set; }
        public BillingStrategy DefaultBillingStrategy {get; private set; }
        //Other properties
        
            public Membership(string name, BillingStrategy defaultBillingStrategy)
            {
            
                Name = name;
                DefaultBillingStrategy = defaultBillingStrategy;
            
            }
    
    }
