    private GameEngine.Inventory _inventory;
    public GameEngine.Inventory Inventory
    {
      get { 
        if (_inventory == null) {
           _inventory = GameEngine.Instance.Inventory;
         } 
 
         return _inventory;
      }
    }
