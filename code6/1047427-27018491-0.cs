    public class SomeClass : UsersConsumer 
    {
        public void consume(List<User> collection)
        {
            List<User> SortedUserList = collection.OrderByDescending(row => row.age).ToList();
        }
    }	
