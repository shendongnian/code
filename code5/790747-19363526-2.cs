    class Program
    {
        delegate void lol (int A);
         string myX;
        static void Main(string[] args)
        {
            lol x = ... // THIS WILL CREATE DELEGATE INSTANCE
            x(3) // THIS WILL INVOKE THE DELEGATE
            myX //does not exist, 
        }
    }
