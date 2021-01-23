	public class GNCEngineer : ISerializable
	{
		public Bike Bike { get; set; }
		public Car Car { get; set; }
		public Plane AirPlane { get; set; }
		public static void SerializeItem(string fileName, IFormatter formatter)
		{ 
			// let serializer do their work 
		}
		public static void DeserializeItem(string fileName, IFormatter formatter)
		{
			// Ignore airplane and let rest work.
		}
	}
