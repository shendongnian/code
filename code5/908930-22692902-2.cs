    public class PricelessBond // :)
    {
        public int ID {get; set;}
    }
    public class Bond : PricelessBond
    {
        public List<Price> Prices {get; set;}
    }
