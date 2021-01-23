	interface UnitDefinition
	{
		public ResourceCost resourceCost;
		public string name;
	}
	class FireTowerDefinition : UnitDefinition
	{
		public ResourceCost resourceCost = new ResourceCost(50, 50, 20);
		public string name = "Fire Tower";
	}
	class UnitInstance
	{
		public UnitDefinition unitDefinition;
		public int HP;
		public Point PositionOnMap;
		// etc... and other attributes that are per instance
	}
	....
	class MyGame
	{
		// this list is pretty much static...
		public UnitDefinition[] catalog = { new FireTowerDefinition(), new OtherThingDefinition() };
		// this list changes throughout gameplay
		public List<UnitInstances> unitInstances;
	}
