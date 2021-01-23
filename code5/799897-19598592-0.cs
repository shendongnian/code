    public class User
    {
        public int UserID {get;set;}
        public string Account {get;set;}
        public string Pass {get;set;}
        ......
    }
    User u = cnn.Query<User>("spGetUser", new {Id = 1}, 
             commandType: CommandType.StoredProcedure).First();}}}
