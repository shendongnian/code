    public class CraftableItem 
    {
        public List<ResourceNumber> RequiredResources = new List<ResourceNumber>();
        // Other properties / methods
    }
    Then you have one global property in your program for each resource:
    CraftableItem CraftableFireTower {
        get { 
            if ( _CraftableFireTower == null ) {
                _CraftableFireTower = new CraftableItem();
                _CraftableFireTower.Add( new ResourceNumber( ResourceType.WOOD, 100 );
                _CraftableFireTower.Add( new ResourceNumber( ResourceType.STONE, 50);
            }
            return _CraftableFireTower; 
        }
    }
    private CraftableItem _CraftableFireTower
      
