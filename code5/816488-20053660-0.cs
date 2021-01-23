    public enum UserType {
        NotSet = 0,
        Admin,
        Moderator
    }
    public class User
    {
        public UserType Type {get; set; }
        public string TypeOfUser() {
            return Type.ToString();
        }
    }
