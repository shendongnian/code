    public class Auction {
       public int Id { get; set;}
    
       public virtual User Seller {get; set;}
       public virtual User Winner {get; set;}
    }
