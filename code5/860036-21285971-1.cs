    private static GameEngine.Inventory _inventory;
    public static GameEngine.Inventory Inventory
    {
      get { 
        if (_inventory == null) {
           _inventory = GameEngine.Instance.Inventory;
         } 
 
         return _inventory;
      }
    }
