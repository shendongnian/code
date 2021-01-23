        //Create an instance of user in your application where you allow setting and getting the Name.
        public class User : IUser
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public event Action OnLogin = delegate { };
        }
        
        //Only allow the developers to get the name/id
        public interface IUser
        {
            string Name { get; }
            string Id { get; }
            event Action OnLogin;
        }
