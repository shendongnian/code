       double value;
    
     value = 123;
     Console.WriteLine(value.ToString("00000"));
     Console.WriteLine(String.Format("{0:00000}", value));
     // Displays 00123 
    
     value = 1.2;
     Console.WriteLine(value.ToString("0.00", CultureInfo.InvariantCulture));
     Console.WriteLine(String.Format(CultureInfo.InvariantCulture, 
                       "{0:0.00}", value));
     // Displays 1.20
    
     Console.WriteLine(value.ToString("00.00", CultureInfo.InvariantCulture));
     Console.WriteLine(String.Format(CultureInfo.InvariantCulture, 
                                     "{0:00.00}", value));
     // Displays 01.20
    
     CultureInfo daDK = CultureInfo.CreateSpecificCulture("da-DK");
     Console.WriteLine(value.ToString("00.00", daDK)); 
     Console.WriteLine(String.Format(daDK, "{0:00.00}", value));
     // Displays 01,20 
    
     value = .56;
     Console.WriteLine(value.ToString("0.0", CultureInfo.InvariantCulture));
     Console.WriteLine(String.Format(CultureInfo.InvariantCulture, 
                                     "{0:0.0}", value));
     // Displays 0.6 
    
     value = 1234567890;
     Console.WriteLine(value.ToString("0,0", CultureInfo.InvariantCulture));	
     Console.WriteLine(String.Format(CultureInfo.InvariantCulture, 
                                     "{0:0,0}", value));	
     // Displays 1,234,567,890      
    
     CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
     Console.WriteLine(value.ToString("0,0", elGR));	
    Console.WriteLine(String.Format(elGR, "{0:0,0}", value));	
     // Displays 1.234.567.890 
    
     value = 1234567890.123456;
     Console.WriteLine(value.ToString("0,0.0", CultureInfo.InvariantCulture));	
     Console.WriteLine(String.Format(CultureInfo.InvariantCulture, 
                                     "{0:0,0.0}", value));	
     // Displays 1,234,567,890.1   
    
     value = 1234.567890;
     Console.WriteLine(value.ToString("0,0.00", CultureInfo.InvariantCulture));	
     Console.WriteLine(String.Format(CultureInfo.InvariantCulture, 
                                     "{0:0,0.00}", value));	
     // Displays 1,234.57 
