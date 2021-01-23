    public static void Write(Exception exception)
    {
        string logfile = String.Empty;
        try
        {
            
    using (StreamWriter sr = File.AppendText("result.txt"))//new StreamWriter("result.txt", Encoding. ))
                    {
        
                        sr.WriteLine("=>" + DateTime.Now + " " + " An Error occurred: " + exception.StackTrace +
                                    " Message: " + exception.Message + "\n\n");
                        sr.Flush();
    
    }
    return false;
    
        catch (Exception e)
        {
            throw;
        }
    
    }
