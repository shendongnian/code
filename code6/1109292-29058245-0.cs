    List<string>directories= yourlistofdirectories.
    
        foreach(dir in directories)
      {
        
            DirectoryInfo d = new DirectoryInfo(dir);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.jpg"); //Getting image files
            foreach(FileInfo file in Files )
            {
              String query = "INSERT INTO dbo.Name (name) VALUES(@name)";
              SqlCommand command = new SqlCommand(query, db.Connection);
              command.Parameters.Add("@name",dir+file.Name);
              command.ExecuteNonQuery();
        
            }
