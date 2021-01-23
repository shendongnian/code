    StreamReader myStreamReader = null;
    
    try
    {
       myStreamReader = new StreamReader("c:\\genneric.txt");   
       Console.WriteLine(myStreadReader.ReadToEnd());       
    }
    
    catch(FileNotFoundException Error)
    {
       Console.WriteLine(Error.Message);
       Console.WriteLine(); 
       throw;
    }
    
    catch(Exception Error)
    {
       Console.WriteLine(Error.Message);
       Console.WriteLine();
    }
    
    finally
    {
      Console.WriteLine("Closing the StreamReader.");
      try{
        if(myStreamReader != null)
       {
          myStreamReader.Close();
       }
      } catch(Exception e) {  Console.WriteLine(e.ToString())  };
    }
    
      
    }
