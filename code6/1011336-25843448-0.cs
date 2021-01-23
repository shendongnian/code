    public class Item
    {
       public int ID {get; set;}
       public string Name {get; set;}
       public int ParentID {get; set;}
       public Item Parent {get; set;}
       public List<Item> Children {get; set;}
    }
