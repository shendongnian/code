	public class Profile
    { 
	
		public Dictionary<string, string> ProfileDetails {get; set;}
		
		public Profile()
		{
			ProfileDetails = new Dictionary<string, string>()
			{
				{"HighSchool", ""},
				{"UndergraduateSchool", ""},
				{"GraduateSchool", ""},
			};
		}
    }
