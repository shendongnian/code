    class Biscuit
    {
        public string Brand { get; set; }
        public string Variant { get; set; }
    
        public Biscuit(string brand, string variant)
        {
            Brand = brand;
            Variant = variant;
        }
    
        public override bool Equals(object obj)
        {
            if (obj == null || typeof(Biscuit) != obj.GetType())
                return false;
        
            Biscuit biscuitObj = obj as Biscuit;
        
            return biscuitObj.Brand == this.Brand && biscuitObj.Variant == this.Variant;
        }
    
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.Brand.GetHashCode();
                hash = hash * 23 + this.Variant.GetHashCode();
                return hash;
            }
        }   
    }
