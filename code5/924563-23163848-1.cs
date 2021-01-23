    [Serializable]
    public class Item
    {
        public string Code {get;set;}
        public string Description {get;set;}
        public string Price {get;set;}
    }
    
    List<Item> cart=new List<Item>();
    Item item=new Item();
    item.Code=productLabel.Text;
    item.Description=descriptionTextBox.Text;
    item.Price=priceLabel.Text;
    cart.Add(item);
    Session["cart"]=cart;
    
    //then later pull it out...
    List<Item> cart=Session["cart"] as List<Item>; //youll want to check for null etc
    //and add another item
    Item newItem=new Item();
    newItem.Code=productLabel.Text;
    newItem.Description=descriptionTextBox.Text;
    newItem.Price=priceLabel.Text;
    cart.add(newItem);
