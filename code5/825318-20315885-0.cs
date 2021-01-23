    HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
    try
    {
        // response handling
    }
    catch (WebException wex3)
    {
        Console.WriteLine(wex3);
        Console.WriteLine(wex3.Status);
    }
    finally
    {
         response3.Close();
    }
        
