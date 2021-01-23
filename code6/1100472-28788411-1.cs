    class DashContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
    	protected override string ResolvePropertyName(string propertyName)
    	{
    		// Count capital letters
    		int upperCount = propertyName.Skip(1).Count(x => char.IsUpper(x));
    		// Create character array for new name
    		char[] newName = new char[propertyName.Length + upperCount];
    		// Copy over the first character
    		newName[0] = char.ToLowerInvariant(propertyName[0]);
    
    		// Fill the character, and an extra dash for every upper letter
    		int iChar = 1;
    		for (int iProperty = 1; iProperty < propertyName.Length; iProperty++)
    		{
    			if (char.IsUpper(propertyName[iProperty]))
    			{
    				// Insert dash and then lower-cased char
    				newName[iChar++] = '-';
    				newName[iChar++] = char.ToLowerInvariant(propertyName[iProperty]);
    			}
    			else
    				newName[iChar++] = propertyName[iProperty];
    		}
    
    		return new string(newName, 0, iChar);
    	}
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		string json = @"{""text-example"":""hello""}";
    		var anonymous = new { textExample = "" };
    		var obj = JsonConvert.DeserializeAnonymousType(json, anonymous,
    			new JsonSerializerSettings
    			{
    				ContractResolver = new DashContractResolver()
    			});
    
    
    	}
    }
