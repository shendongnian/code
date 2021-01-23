    //json string... I had to remove the double quotes to make it clearer.
    string jsonString = @"{
        'User': {
            'User': {
                'id': '3',
                'first_name': 'ABC',
                'last_name': 'Kumar',
                'email': 'vinod.kumar@abc.com',
                'role': 'admin'
            }
        }
    }";
    JavaScriptSerializer js = new JavaScriptSerializer();
    object obj = js.Deserialize(jsonString, typeof(User1));
    User1 k = (User1)obj;
    //id can be accessed by
    int userid = k.User.User.id;
    //nested user class
    namespace JsonTest
    {
        //main user
        public class User1
        {
            public User2 User;
        }
        //user2 is nested in user 1
        public class User2
        {
            public User User;
        }
        //final user is nested in User2.
        //note that the property name is User in all cases.
        public class User
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public string email { get; set; }
            public string role { get; set; }
        }
         
    }
