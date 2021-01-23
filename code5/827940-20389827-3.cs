    public void MyMethod()
    {
        // get records with the id 4
        var myList = GetMyList(4);
    
        // get the property called Column1 for each one of those records and add them to this list (for demonstration)
        var listOfColumn1 = new List<string>(); // lets assume that column holds a string
        foreach(User usr in myList)
        {
            listOfColumn1.Add(thing);
        }
    
        // or in a more linq-ish way
        listOfColumn1 = myList.Select(record => record.Column1).ToList();
    
    }
    
    public List<User> GetMyList(int departmentId)
    {
        // return a list of users that have the specified department id
        return MyEntities.Users.Where(user => user.DepartmentId== departmentId).ToList();
    }
    
    
    // OR do it in one operation
    public void DisplayDepartmentUsers(int departmentId)
    {
    	MyEntities.Users // from my user table
    		.Where(user => user.DepartmentId == departmentId) // get everyone with this department id
    		.Select(record => record.Column1) // only select the first column (a string in this case)
    		.ToList() // make a list out of the resultant enumerable
    		.ForEach(Console.WriteLine); // for each result, run this method (write out to console)
    }
