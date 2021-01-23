    String strDate = "10:00 AM";
    String HH = strDate.Substring(0, 2);//10
    String MM = strDate.Substring(3, 2);//00
    String tt= strDate.Substring(6, 2);//AM
    
    Console.WriteLine(HH+":"+MM+" "+tt);
        
