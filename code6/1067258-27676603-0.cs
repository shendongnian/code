    int i = 1;
    string input = "FGS1=(B+A*10)+A*10+(C*10.5)";	
    var lookUp = new Dictionary<string, string>();
    var output = Regex.Replace(input, 
    			 "([A-Z][A-Z\\d]*)", 
    			 m => { 
    				if(!lookUp.ContainsKey(m.Value))
    				{			
    					lookUp[m.Value] = "i" + i++; 			
    				}
    				return lookUp[m.Value]; 
    			});
    Console.WriteLine(output);		//i1=(i2+i3*10)+i3*10+(i4*10.5)
