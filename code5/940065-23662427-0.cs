	public struct Upgrade
	{
		public string Name;
		public int Cost;
		public float Value;
		
		public Upgrade(string name, int cost, float value)
		{
			this.Name = name;
			this.Cost = cost;
			this.Value = value;
		}
	}
	public class UpgradeButtons : MonoBehavior
	{
		List<Upgrade> Upgrades = new List<Upgrade>();
		
		public void CreateButtons()
		{
			Upgrades.Add(new Upgrade("Autoclicker", 10, 0.1f));
			//etc...
		}
		
		public void somefunction()
		{
			Upgrade autoclickUpgrade = Upgrades.Where(p => p.Name == "Autoclicker").FirstOrDefault();
			
			if(autoclickUpgrade == null)
				throw new Exception("Could not find Autoclicker upgrade.");
				
			//do something with autoclickUpgrade
		}
	}
