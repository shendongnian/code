    using (IDbConnection db = dbFactory.OpenDbConnection())
    {
    	// create temp file, read bytes, delete it
    	var tmp = Path.GetTempFileName();
    	using (var fs = new FileStream(tmp, FileMode.OpenOrCreate))
    	{
    		var textBytes = System.Text.Encoding.UTF8.GetBytes("some text");
    		fs.Write(textBytes, 0, textBytes.Length);
    	}
    	byte[] bytes = File.ReadAllBytes(tmp);
    	File.Delete(tmp);
    
    
    	// stand up data in orm lite
    	db.CreateTableIfNotExists<FileExample>();
    
    	// here is our extension method - note that this will drop the entire file column
    	// and lose all existing data
    	db.UpdateByteToBinary<FileExample>();
    
    	db.Insert<FileExample>(new FileExample { Name = "my new file", FileBytes = bytes  });
    
    	// read data back to ensure it saved properly
    	var files = db.Select<FileExample>();
    
    	using (var ms = new MemoryStream(files[0].FileBytes))
    	{
    		var someText = System.Text.Encoding.UTF8.GetString(files[0].FileBytes);
    
    		Console.WriteLine(someText);
    	}
    
    	db.DropTable<FileExample>();
    }
