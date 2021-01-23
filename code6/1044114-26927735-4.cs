    public class User
    {
        [Key]
        public int ID { get; set; }   
        //whole bunch of other properties like 'username' etc.
        //I have switched back to List<T> after using IEnumerable because despite what I keep reading
        //you can use them, and I ran into problems using .ToList() where the results were empty.
        public List<User> Friends { get; set; }
        public User()
        {
            //Removed this line because the instance is created when we get the user using DbContext 
            //this.Friends = new List<User>();
        }
    }
