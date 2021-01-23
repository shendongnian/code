    private static bool StringToColor(string strColor, out Color color)
    {
    	string xaml = string.Format("<Color xmlns=\"schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\">{0}</Color>", strColor);
    	try
    	{
    		object obj = XamlReader.Load(xaml);
    		if (obj != null && obj is Color)
    		{
    			color = (Color)obj;
    			return true;
    		}
    	}
    	catch (Exception)
    	{
    		//Swallow useless exception
    	}
    	color = new Color();
    	return false;
    }
