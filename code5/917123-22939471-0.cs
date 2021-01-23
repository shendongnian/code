    public class Item
    { 
      public int Id { get; set; }
      public string Name { get; set; }
      public Item(Item i)
      {
          Id = i.Id;
          Name = i.Name;
          ...
      }
    }
    List<Item> itemsWithIdGreaterThan3 = items.Where(i => i.Id >= 3)
             .Select(i => new Item(i)).ToList();
