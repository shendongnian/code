    class Book
    {
       　 public Book(decimal price, int number)
       　 {
             LatestPrice  = price;
             Quantity  = number;
         }
       　public decimal LatestPrice { get; private set; }
      　 public int Quantity { get; private set; }
       　public decimal TotalOrder { get{ return LatestPrice * Quantity;} private set{}}
    }
   
