	   //Convert to Json
		string json = JsonConvert.SerializeObject(user, Formatting.Indented);
		
		//Write to file, you will have to create a file serverside if you want
		//if you have a 
		File.WriteAllText(@"location.json", json);
   }
           
    
       
       public void LoadUser(){
    	    using (StreamReader r = new StreamReader("Location.json"))
        {
            string json = r.ReadToEnd();
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
