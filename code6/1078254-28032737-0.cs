    private class Movie 
    {
        private readonly int _defaultLength = 90;
        public string Title { get; set; }
        public int Length { get; set; }
        // constructor without length - use default length
        public Movie(string title)
        {
            this.Title = title;
            this.Length = _defaultLength;
        }
        // constructor with both properties
        public Movie(string title, int length)
        {
            this.Title = title;
            // make sure Length is valid
            if (length > 0)
                this.Length =length;
            else
                this.Length = _defaultLength;
        }
    }
    static void Main()
    {
        // make a Movie object without length
        var shortMovie = new Movie("Zombieland");
        // make a Movie object and specify length
        var longMovie = new Movie("Lawrence of Arabia", 216);
        Console.WriteLine("{0} is {1} minutes long", shortMovie.Title, shortMovie.Length);
        Console.WriteLine("{0} is {1} minutes long", longMovie.Title, longMovie.Length);
        // get input from user: title
        Console.Write("What is the name of another movie?");
        var userTitle = Console.ReadLine();
        // get input from user: length
        Console.Write("What is the length of {0}? Default is 90 if left blank", userTitle);
        var userTime = Console.ReadLine();
        // try to convert user input to an int (will remain 0 if invalid)
        int userTimeConverted = 0;
        Int32.TryParse(userTime, out userTimeConverted);
        // make a new Movie object with the user's input
        var userMovie = new Movie(userTitle, userTimeConverted);
        Console.WriteLine("{0} is {1} minutes long", longMovie.Title, longMovie.Length);
    }
