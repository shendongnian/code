    // This is a class that represents a row of your DataTable.
    public class User
    {
        public int UserNbr { get; set;}
        public User(int userNbr)
        {
            UserNbr = userNbr;
        }
    }
    public List<User> allUsers ()
    {
        var users = new List<User>();
        // Create an instance of the DAL class.
        var dal = new Restaurang4.DAL();
        // Loop through the datatable's rows and create foreach of them 
        // a new User and then add it to the users list.
        foreach(var dataRow in dal.findAllUsers().Rows)
            users.Add(new User(dataRow.Field<int>("UserNbr ")));
        return users;
    }
