    public static class ExtensionString
    {
    	private static Dictionary<string, string> _replacements = new Dictionary<string, string>();
    
    	static ExtensionString()
    	{
    		_replacements["LINESTRING"] = "";
    		_replacements["CIRCLE"] = "";
    		_replacements["POLYGON"] = "";
    		_replacements["POINT"] = "";
    		_replacements["("] = "";
    		_replacements[")"] = "";
    	}
    
    	public static List<Point> ParseGeometryData(this string s)
    	{
    		var points = new List<Point>();
    
    		foreach (string to_replace in _replacements.Keys)
    		{
    			s = s.Replace(to_replace, _replacements[to_replace]);
    		}
    
    		string[] pointsArray = s.Split(',');
    
    		for (int i = 0; i < pointsArray.Length; i++)
    		{
    			double[] coordinates = new double[2];
    
    			//gets x and y coordinates split by space, trims whitespace at pos 0, converts to double array
    			coordinates = Array.ConvertAll(pointsArray[i].Remove(0, 1).Split(null), double.Parse);
    
    			points.Add(new Point() { X = coordinates[0], Y = coordinates[1] });
    		}
    
    		return points;
    	}
    }
