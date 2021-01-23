		void Main()
		{
		
			// Create Tables and Initialize values
			// ***********************************
			var techniqueSettings = new List<TechniqueSettings>();
			techniqueSettings.Add(new TechniqueSettings { Id = 1, Override = "Default", SettingKeyId = 3, Technique="BAZ"});
			techniqueSettings.Add(new TechniqueSettings { Id = 2, Override = "Default", SettingKeyId = 4, Technique="BAZ"});
			techniqueSettings.Add(new TechniqueSettings { Id = 3, Override = "FOO", SettingKeyId = 7, Technique="BAZ"});
			techniqueSettings.Add(new TechniqueSettings { Id = 4, Override = "FOO", SettingKeyId = 8, Technique="BAZ"});	
			
			var imageSettingOverrides = new List<ImageSettingOverrides>();
			imageSettingOverrides.Add(new ImageSettingOverrides {SettingId = 1, ImageId=1, Override=null } );
			imageSettingOverrides.Add(new ImageSettingOverrides {SettingId = 2, ImageId=1, Override="FOO" } );
			imageSettingOverrides.Add(new ImageSettingOverrides {SettingId = 3, ImageId=1, Override="FOO" } );
				
			var settingKeyValues = new List<SettingKeyValues>();
			settingKeyValues.Add(new SettingKeyValues {Id = 4, Setting="Wait", Value=1000 } );
			settingKeyValues.Add(new SettingKeyValues {Id = 7, Setting="Wait", Value=10000 } );
		
			
			int myImageId = 1;
			string myOverride = "FOO";
			string myTechnique = "BAZ";
					
			var results = from iso in imageSettingOverrides
					join ts in techniqueSettings on iso.SettingId equals ts.Id
					join skv in settingKeyValues on ts.SettingKeyId equals skv.Id
					where iso.ImageId == myImageId &&
						//iso.Override.Equals(myOverride,StringComparison.InvariantCultureIgnoreCase)  &&
						ts.Override.Equals(myOverride,StringComparison.InvariantCultureIgnoreCase)  &&
						ts.Technique.Equals(myTechnique, StringComparison.InvariantCultureIgnoreCase) 
					select new {
						ImageId = iso.ImageId,
						Override = ts.Override,
						Value = skv.Value
					};
					
			
			results.Dump();
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
