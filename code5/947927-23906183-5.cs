    try{
       Console.WriteLine(tTime.Value.ToString("hh:mm tt"));
    }
    catch(Exception e){
       // You don't actually need the 'Exception e', 
       // however 'e.Message' will tell you exactly what went wrong
       Console.WriteLine(String.Empty);
    }
