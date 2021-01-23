     public class Item 
       {
          public Item()
          {
                ChildItems = new HashSet<Item>();
          }
    
          public int Id { get; set; }
          public int? ParentItemId { get; set; }
          public string Value { get; set; }
    
          public virtual Item ParentItem { get; set; }
          public virtual ICollection<Item> ChildItems { get; set; }
      }
