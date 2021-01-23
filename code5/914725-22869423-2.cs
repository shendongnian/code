    string path = string.Concat(Server.MapPath("~/TempFiles/"), Fileupload1.FileName);
    string text = System.IO.File.ReadAllText(path);
    string[] lines = text.Split(' ');
    con.Open();
    string[] Values;
    foreach (string line1 in lines)
    {
        Values = line1.Split(';');
            
        if (Values.Length >= 3)
        {
            string query = "INSERT INTO demooo VALUES ('" + Values[0] + "','" + Values[1] + "','" + Values[2] + "')";
        }
        else
        {
          //Some error occured
        }
    
        using (var cmd = new SqlCommand(query,con))
        {
            cmd.ExecuteNonQuery();
        }
    }
