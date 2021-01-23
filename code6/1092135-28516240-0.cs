    try 
    {
    
      //Pass the filepath and filename to the StreamWriter Constructor
      StreamWriter sw = new StreamWriter("C:\\Test.txt");
    
      //Write a line of text
      sw.WriteLine("Hello World!!");
    
      //Write a second line of text
      sw.WriteLine("From the StreamWriter class");
    
      //Close the file
      sw.Close();
    }
    catch(Exception e)
    {
      Console.WriteLine("Exception: " + e.Message);
    }
    finally 
    {
      Console.WriteLine("Executing finally block.");
    }
