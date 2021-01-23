    public static UserCollection GetUserCollection()
    {
       DataTable table = ...//all users data from DB
       List<User> userList = table.ToCollection<User>(); 
       return new UserCollection(userList);
    }
