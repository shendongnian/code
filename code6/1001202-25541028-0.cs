    internal class Program
    {
      
        private static void Main(string[] args)
        {
            GetUsers();  //get users - all of them - from all businesses - disregard any constrain.
            GetUsers(1);          //get users - which belong to business 1, not matter which role.
            GetUsers(1, null);    //get users - which belong to business 1 and have no assinged role.
            GetUsers(roleId: 3);  //get users - from all business which relate to role 3.
            GetUsers(null, null); //syntax error - business cannot be null! (the big benefit)
            GetUsers(1, 3);       //get users - which belong to business 1 and relate to role 3.
        }
        public static List<User> GetUsers(
                         int businessId = int.MinValue, int? roleId = int.MinValue)
        {
            //int.MinValue - to be considered as undefined.
            //this is the only way to keep consistency with the model abstraction.
            
            //can make a chain query here.
            //q1 = select according to business or just bring from all businesses.
            //q2 = q1. Select according to roleId..
            //and so on if more parameters involved..
            
            //return final query result.
        }
    }
