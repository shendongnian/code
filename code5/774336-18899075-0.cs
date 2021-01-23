    class Program
    {
        static void Main(string[] args)
        {
            var authorsList = new List<Author>()
            {
                new Author{ Firstname = "Bob", Lastname = "Smith", Age=11 },
                new Author{ Firstname = "Bob", Lastname = "Smith", Age=20 },
                new Author{ Firstname = "Bob", Lastname = "Smith", Age=12 },
                new Author{ Firstname = "Bob", Lastname = "Smith", Age=14 },
                new Author{ Firstname = "Bob", Lastname = "Smith", Age=12 },
                new Author{ Firstname = "Fred", Lastname = "Smith", Age=12 },
                new Author{ Firstname = "Trevor", Lastname = "Smith", Age=15 },
                new Author{ Firstname = "Brian", Lastname = "Smith", Age=11 },
                new Author{ Firstname = "Billy", Lastname = "Smith", Age=11 },
            };
            var authorsListExcept = new List<Author>()
            {
                new Author{ Firstname = "Bob", Lastname = "Smith", Age=12 },
                new Author{ Firstname = "Fred", Lastname = "Smith", Age=12 },
            };
            var authorsList2 = authorsList.Where(x => !authorsListExcept.Any(y => y.Firstname == x.Firstname && y.Lastname == x.Lastname && x.Age <= y.Age));
        }
    }
    public class Author
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }
