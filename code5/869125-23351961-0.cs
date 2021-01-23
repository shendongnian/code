    public string GetConfig()
    {
    	try
    	{
    		var assembly = Assembly.GetExecutingAssembly();
			var resourceName = "MyCompany.MyProduct.MyFile.cfg";
			
			// ArgumentNullException
			// ArgumentException
			// FileLoadException
			// FileNotFoundException
			// BadImageFormatException
			// NotImplementedException
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			// ArgumentException
			// ArgumentNullException
			using (StreamReader reader = new StreamReader(stream))
			{
			    // OutOfMemoryException
			    // IOException
			    string result = reader.ReadToEnd();
			}
			return result;
    		
    		// TODO: Read config parameter from DB 'Configuration'
    	}
    	catch (Exception ex)
    	{
    		throw new ConfigException("Unable to get configuration", ex);
    	}
    }
