    void Main()
    {	
    	string json = "{Title: 'Image title', Description: 'Description', Base64Data : 'iVBORw0KGgoAAAANSUhEUgAAAA0AAAAQCAYAAADNo/U5AAAACXBIWXMAAA......'}";
    	JavaScriptSerializer js = new JavaScriptSerializer();
    	var picture = js.Deserialize<Picture>(json);
    	
    	 
    	
    	// Now deserialize the Base64 encoded picture.
    	picture.Data = Convert.FromBase64String(picture.Base64Data);
    	
    	File.WriteAllBytes(@"C:\test.png", picture.Data);
    }
    
    class Picture
    {
    	public string Title {get; set;}
    	public string Description {get; set;}
    	public byte[] Data {get; set;}
    	public string Base64Data {get; set;}
    }
