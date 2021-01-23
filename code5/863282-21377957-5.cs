    class MyDB
     {
        
        List<User> list = new List<User>();
            
        public void add()
        {
             //use constructor to create new object
             User person = new User("Jurand", "ze Spychowa","15231512","1410-10-26","hue@dupa.com");
             //add object to list
             list.Add(person);
        }
     }
