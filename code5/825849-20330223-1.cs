    string val=listView1.Columns[2].ToString(); 
   
    double i; 
    if(Double.TryParse(val, out i)) 
    {
    	Console.WriteLine(Math.Round(i)); // you can use Math.Round without second
                                          // argument if you need rounding to the 
                                          // nearest unit  
    }
