    public class User // a class for holding details about a user
    {
        public int UserID {get;set;}
        //others
    }
    // a list holding the users you want to insert
    List<User> usersToInsert = new List<User>();
    // get the users in some way
    usersToInsert = TheSelectStatementToGetUsersToInsert();
