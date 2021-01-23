    public class Market
    {
         public string _items {get;set;}
         public string _price {get;set;}
         public override string ToString()
         {
             return this._items + " $ " + this._price
         }
    }
