    public class User {
        public int UserId {get; set;}
        public string Username {get; set;}
        public string Email{
            get
            {
                return UserId;
            }
            set 
            {
                UserId = value;
            }
        }
