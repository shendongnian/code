	interface Unit
	{
		public ResourceCost resourceCost;
		public string name;
	}
	class FireTowerDefinition : Unit
	{
		public ResourceCost resourceCost = new ResourceCost(50, 50, 20);
		public string name = "Fire Tower";
	}
	class UnitInstance
	{
		public Unit unitDefinition;
		public int HP;
		public Point PositionOnMap;
		// etc... and other attributes that are per instance
	}
	....
	class MyGame
	{
		// this list is pretty much static...
		public Unit[] catalog = { new FireTowerDefinition(), new OtherThingDefinition() };
		// this list changes throughout gameplay
		public List<UnitInstances> unitInstances;
	}
