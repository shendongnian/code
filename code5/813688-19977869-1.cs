    using (System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath(@"~/Experiment/main.txt"), true))
    {
         file.WriteLine(DateTime.UtcNow.ToString() + " test");
    }
        
