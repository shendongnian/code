    public static string Serialize(T pSettings)
    {
    	return (new JavaScriptSerializer()).Serialize(pSettings);
    }
    
    public static T Load(string fileName)
    {
        T t = new T();
    	if (File.Exists(fileName))
    		try
    		{
    			t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
    			var s = t as SettingsFoo;
    			if (s != null)
    				s.FileName = fileName;
    		}
    		catch (Exception ex)
    		{
    			Trace.WriteLine(string.Format("failed to parse settings file {0}", fileName));
    			Trace.WriteLine(ex.Message);
    		}
    	else
    	{
    		Trace.WriteLine(string.Format("failed load settings '{0}' absolute '{1}'", fileName, Path.GetFullPath(fileName)));
    		Save(t);
    	}
        return t;
    }
