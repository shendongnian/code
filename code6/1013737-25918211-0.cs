	void Main()
	{
		var xml = @"<Skills>
						<Fire>
							<Cast>0.00</Cast>
							<ReCast>90.00</ReCast>
							<MPCost>0</MPCost>
							<Button>8</Button>
						</Fire>
						<Ice>
							<Cast>5.98</Cast>
							<ReCast>2.49</ReCast>
							<MPCost>0</MPCost>
							<Button>9</Button>
						</Ice>
					</Skills>";
					
		using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
		{
			var serializer = new XmlSerializer(typeof(Skills));
			var skills = (Skills)serializer.Deserialize(memoryStream);
			// good to go!
		}
	}
	
	public class Skill
	{
		public double Cast { get; set; }
		public double ReCast { get; set; }
		public int MPCost { get; set; }
		public int Button { get; set; }
	}
	
	public class Skills
	{
		public Skill Fire { get; set; }
		public Skill Ice { get; set; }
	}
