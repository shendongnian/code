    static void getIntsFromFile(string filein, ref double[] acc, ref double[] period)
    {
    	string line;
    	
    	List<double> p1 = new List<double>();
    	List<double> p2 = new List<double>();
    
    	System.IO.StreamReader file = new System.IO.StreamReader(filein);
    	while ((line = file.ReadLine()) != null)
    		try {
    			String[] parms = line.Trim().Split(',');
    			
    			p1.Add(double.Parse(parms[1], CultureInfo.InvariantCulture));		
    			p2.Add(double.Parse(parms[0], CultureInfo.InvariantCulture));
    		}
    		catch { }
    
    	acc = p1.ToArray();
    	period = p2.ToArray();
    }
