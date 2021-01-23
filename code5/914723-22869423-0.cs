     string path = string.Concat(Server.MapPath("~/TempFiles/"), Fileupload1.FileName);                       
        string text = System.IO.File.ReadAllText(path);               
        string[] lines = text.Split(' ');                                  
        con.Open();                 
        SqlCommand cmd = new SqlCommand();                 
        string[] Values;                                 
        foreach (string line1 in lines)                 
        {                     
            Values = line1.Split(';');
            
    if (Values.Length <4)
    {                                  
            string query = "INSERT INTO demooo VALUES ('" + Values[0] + "','" + Values[1] + "','" + Values[2] + "')";
             }             
              else
                    //Some error occured      
            cmd = new SqlCommand(query,con);                     
            cmd.ExecuteNonQuery();                  
        }
