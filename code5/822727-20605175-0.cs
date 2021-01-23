    partial class tblUser
    {
        public tblUser()
        {
            Surname = "Smith";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestEntities test = new TestEntities();
            var user = test.tblUsers.CreateObject();
            Console.WriteLine(user.Surname);
            // Prints Smith
        }
    }
