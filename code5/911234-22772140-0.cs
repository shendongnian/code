    class Program
    {
        static Player CurrentUser;
        static void Main(string[] args)
        {
            string username;
            bool isValidUser;
            //get and validate user credentials
            if (isValidUser)
                CurrentUser = new Player(username);
            SomeMethod();
        }
        static void SomeMethod()
        {
            if (CurrentUser == null)
                return;
            //do stuff with user
        }
    }
    public class Player
    {
        public string Name { get; private set; }
        //... more properties
        public Player(string name)
        {
            Name = name;
            //... more properties
        }
    }
