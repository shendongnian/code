	// Example model
	public enum enumBuilding { Hotel, House, Skyscraper };
	public enum enumFloor { Basement, GroundFloor, Penthouse };
	public enum enumRoom { Entry, Office, Toilet };
	public abstract class EnumArray
	{
		static protected Building[] buildings;
		static EnumArray()
		{
			buildings = new Building[Enum.GetValues(typeof(enumBuilding)).Length];
			for (int i = 0; i < buildings.Length; i++)
				buildings[i] = new Building(i);
		}
		public static Building Hotel { get { return buildings[0]; } }
		public static Building House { get { return buildings[1]; } }
		public static Building Skyscraper { get { return buildings[2]; } }
	}
	public class Building
	{
		protected Floor[] floors;
		public Building(int start)
		{
			floors = new Floor[Enum.GetValues(typeof(enumFloor)).Length];
			for (int i = 0; i < floors.Length; i++)
				floors[i] = new Floor(start + i * floors.Length);
		}
		public Floor Basement { get { return floors[0]; } }
		public Floor GroundFloor { get { return floors[1]; } }
		public Floor Penthouse { get { return floors[2]; } }
	}
	
	public class Floor
	{
		protected int[] rooms;
		public Floor(int start)
		{
			rooms = new int[Enum.GetValues(typeof(enumRoom)).Length];
			for (int i = 0; i < rooms.Length; i++)
				rooms[i] = new Room(start + i * rooms.Length);
		}
		public int Entry { get { return rooms[0]; } }
		public int Office { get { return rooms[1]; } }
		public int Toilet { get { return rooms[2]; } }
	}
			var index = EnumArray.Hotel.Basement.Office;
