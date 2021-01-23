	void Main()
	{
	
		
		var techniqueSettings = new List<TechniqueSettings>();
		techniqueSettings.Add(new TechniqueSettings { Id = 1, Override = "Default", SettingKeyId = 3, Technique="BAZ"});
		techniqueSettings.Add(new TechniqueSettings { Id = 2, Override = "Default", SettingKeyId = 4, Technique="BAZ"});
		techniqueSettings.Add(new TechniqueSettings { Id = 3, Override = "FOO", SettingKeyId = 7, Technique="BAZ"});
		techniqueSettings.Add(new TechniqueSettings { Id = 4, Override = "FOO", SettingKeyId = 8, Technique="BAZ"});	
		
	
		var techniqueName = "BAZ";
		var overridesName = "DEFAULT";
                //var overridesName = "";
		
		// using inline if
		// **********************
		var result = (overridesName.Equals("Default", StringComparison.InvariantCultureIgnoreCase)
			? from r in techniqueSettings 
			where r.Technique.Equals(techniqueName, StringComparison.InvariantCultureIgnoreCase) 
			select r
			: from r in techniqueSettings 
			where !r.Override.Equals("Default" ,StringComparison.InvariantCultureIgnoreCase) 
				&& r.Technique.Equals(techniqueName, StringComparison.InvariantCultureIgnoreCase) 
				select r);
			
			
		result.Dump();
	
				
		
		
	}
	
	// Define other methods and classes here
	public class ImageSettingOverrides
	{
		public int SettingId {get; set;}
		public int ImageId {get; set;}
		public string Override {get; set;}
	}
	
	public class TechniqueSettings
	{
		public int Id {get; set;}
		public string Override {get; set;}
		public int SettingKeyId {get; set;}
		public string Technique { get; set;}
	}
	
	public class SettingKeyValues
	{
		public int Id {get; set;}
		public String Setting {get; set;}
		public int Value {get; set;}
	}
