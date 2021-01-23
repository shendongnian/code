    var path = Server.MapPath(@"~/TextFiles/ActiveUsers.txt");
    
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
    {
        file.WriteLine(model.UserName.ToString());
    }
