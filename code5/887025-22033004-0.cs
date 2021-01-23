      public class Admin
      {
        public string S { get; set; }
      }
    
      public class UserId
      {
        public string S { get; set; }
      }
    
      public class Age
      {
        public string N { get; set; }
      }
    
      public class Promoted
      {
        public string S { get; set; }
      }
    
      public class UserName
      {
        public string S { get; set; }
      }
    
      public class Registered
      {
        public string S { get; set; }
      }
    
      public class RootObject
      {
        public Admin Admin { get; set; }
        public UserId UserId { get; set; }
        public Age Age { get; set; }
        public Promoted Promoted { get; set; }
        public UserName UserName { get; set; }
        public Registered Registered { get; set; }
      }
