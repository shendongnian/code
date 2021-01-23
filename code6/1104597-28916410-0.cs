    class Program
    {
        private string _sPrivate; //This is a private variable, only accessable to methods within the class.
        public string PublicString; //This is a public variable, it is accessable outside the class.
        private void _privateMethod(string this_is_an_argument) //This is a method, since it is private, it is only available inside the above class.
        {
            string thisIsAvar; //this has been defined inside _privateMethod, and is ONLY available inside _privateMethod.
        }
        public void PublicMethod() //This is a public method. It can be called outside the class, on the class itself. Code running in here can still access the private variables inside the class.
        {
            _sPrivate = "I just changed the private var"; //This will work.
            thisIsAvar = "This is impossible, because thisIsAvar doesn't exist here"; //This will throw an error. Since thisIsAvar isn't defined inside this scope.
        }
    }
