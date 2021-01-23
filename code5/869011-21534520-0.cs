    using (var resp = (FtpWebResponse)req.GetResponse())
    {
        Console.WriteLine(resp.WelcomeMessage);
        Stream rs = res.GetResponseStream();
        StreamReader read1 = new StreamReader(rs);// prob A
        Console.WriteLine(read1.ReadToEnd());
        Console.WriteLine("Directory is compleate,status(0)", res.StatusDescription);
    }
