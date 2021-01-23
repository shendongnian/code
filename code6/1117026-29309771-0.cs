    try
    {
         // Your mail code here
    }
    catch (Exception ex)
    {     
        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\log.txt");
        file.WriteLine(ex.StackTrace);
        file.Close();
    }
