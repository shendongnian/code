    [DataContract]
    public class UserInformation
    {
        [DataMember]
        public string Login { get; set; }
    
        [DataMember]
        public string Password { get; set; }
    
        [DataMember]
        public string Type { get; set; }
    
        [DataMember]
        public int ID { get; set; }
    }
    public UserInformation GetUser(string userName, string password)
    {
        UserInformation user = new UserInformation();
        using (QuizDBEntities context = new QuizDBEntities())
        {
            user = (from a in context.UserInfoes
                    where a.UserName == userName && a.Password == password
                    select new UserInformation() {
                        Login = a.UserName,
                        Password = a.Password,
                        Type = a.Type,
                        ID = a.ID}).SingleOrDefault();
        }
        return user;
    }
