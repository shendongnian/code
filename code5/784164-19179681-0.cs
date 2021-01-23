    Class StationaryItem
             {
               int ItemCode;
               String ItemName;
               float Price;
            
             public StationaryItem(int Code, string ItemName,float Price)
                {
                  this.ItemCode = Code;
                  this.ItemName = ItemName;
                  this.Price = Price;
                }
             }
    public static void Main ()
          {
             List<StationaryItem> ItemList = new List<StationaryItems>
             ItemList.Add( new StationaryItem(01,"Pen",20));
             ItemList.Add( new StationaryItem(02,"Pencil",5));
             //After you make a class like this you can use Linq to manuplate easily
          }
