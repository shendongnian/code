    public class Menu
    {
      public Menu()
      {
        Children = new List<Menu>();
      }
      public int MenuID { get; set; }
      public string MenuName { get; set; }
      public string ActionName { get; set; }
      public string ControllerName { get; set; }
      // The collection of sub menus associated with the menus
      public List<Menu> Children { get; set; } 
    }
