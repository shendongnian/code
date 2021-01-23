    void Main()
    {
    	var filePath = @"..."; //insert your file path here
    	var lines = File.ReadLines(filePath); //lazily read and can be started before file is fully read if giant file
    	
    	IList<User> users = new List<User>();
	    var Area = string.Empty;
	    foreach(var line in lines)
	    {
		   if(string.IsNullOrWhiteSpace(line) || 
		       line.Contains("DeltaV User List") ||
		       line.Contains("UserID")
		      )
		   {
			  continue;
		   }
		
		
		var values = line.Split(' ');
		if(values.Length == 1)
		{
                  Area = values[0];
                  continue;
	        }
		
		var currentUser = new User
		{
		  Name = values[0],
		  Area = Area
		};
		users.Add(currentUser);
	  }
	
        users.Dump("User List");
    }
    
    // Define other methods and classes here
    public class User
    {
    	public string Name { get; set;}
    	public string Area { get; set; }
    }
