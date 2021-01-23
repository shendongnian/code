    class Biscuit
    {
        // You should use properties
        public string Brand {get; private set;}
        public string Variant {get; private set;}
    
        // Use a protected constructor so it can't be used outside the class
        protected Biscuit(string brand, string variant)
        {
            Brand = brand;
            Variant = variant;
        }
    
        // Use a static list to hold the already crated biscuits
        private static List<Biscuit> _existingBiscuits = new List<Biscuit>();
    		
        // "Factory method" to create Biscuit instances
        public static Biscuit CreateBiscuit(string pBrand, string pVariant)
        {
            // Use LINQ to find if there are any biscuits already crated with the brand and variant 
            if (_existingBiscuits.Any(b => b.Brand == pBrand && b.Variant == pVariant))
            {
                // If the biscuit already exist return null, no biscuit created
                return null;
            }
            else
            {
                // Create biscuit and add it to the list
                var biscuit = new Biscuit(pBrand, pVariant);
                _existingBiscuits.Add(biscuit);
    			
                return biscuit; 
            }		
        }
    }
