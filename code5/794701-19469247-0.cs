    List<User> users = new List<User>();
    
    public void SearchUser()
    {
    	Console.WriteLine("Enter user id");
    	int userID = Convert.ToInt32(Console.ReadLine());
    	var user = users.Where(i => i.ID == userID).SingleOrDefault();
    	if(user == null)
    	{
    		Console.WriteLine("User not found");
    		return;
    	}
    	Console.WriteLine("User Details:");
    	Console.WriteLine(user.Name);
    	Console.WriteLine(user.Location);
    }
