     class3.cs
      
      public class Class3
      {
	     public static List<_Student> st = new List<_Student>
         {
            
        new _Student { StudentNumber="CE52103-2", 
            FirstName ="AAA", 
            LastName = "BBB", 
            UserName = "CCC",
            Password ="DDD", 
            DateOfBirth = "",
            Gender ="",
            AwardID =""},
        new _Student { StudentNumber="CE52603-2", 
            FirstName ="BBB", 
            LastName = "DDD" , 
            UserName = "FFF",
            Password ="GGG", 
            DateOfBirth = "",
            Gender = "",
            AwardID =""},
        new _Student { StudentNumber="CE52302-2", 
            FirstName ="GGG", 
            LastName = "HHH", 
            UserName = "KKK",
            Password ="LLL", 
            DateOfBirth = "",
            Gender ="",
            AwardID =""}
          
            //return st;
        };
     public static void login( string username, string password)
     {
         var stquery = (from s in st
                        where s.UserName.Equals(username) &&
                       s.Password.Equals(password)
                        select s).FirstOrDefault();
         if (stquery == null)
         {
             //Login failded redirect to registration
             System.Web.HttpContext.Current.Response.Redirect("registration.aspx");
             
         }
         else
         {
             //Login successful redirect to manager
             System.Web.HttpContext.Current.Response.Redirect("manager.aspx");
         }
      }
     }
