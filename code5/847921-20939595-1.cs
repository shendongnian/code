    public class Data
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public virtual Collection<Offer> Offers {get; set;}
    }
