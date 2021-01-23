    using (HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse())
    {
        try
        {
            // response handling
        }
        catch
        {
            Console.WriteLine(wex3);
            Console.WriteLine(wex3.Status);
        }
    }
