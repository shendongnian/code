		var db = new List<string>();
		
		var excludeDatabases = new List<string> { "information_schema","sakila","enrollmentsystem","mysql","world","performance_schema" };
		
		while(reader.Read())
		{
			var data = reader["Database"].ToString();
			
			if(!excludeDatabases.Contains(data)){
			db.Add(data);
			
			}
		}
       reader.Close();
       reader = null;
       dbcmd.Dispose();
       dbcmd = null;
       dbcon.Close();
       dbcon = null;
		
	
        Text = "School Year";
        Size = new Size(340, 240);
        cb = new ComboBox();
        cb.Parent = this;
        cb.Location = new Point(50, 30);
		
		
		databases = db.ToArray();
        cb.Items.AddRange(databases);
