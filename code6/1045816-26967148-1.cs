    public static class MyProcessExtensionMethods
    {
        public static void GoAway(this Process proc)
        {
            Console.WriteLine("Bye");
            this.Kill(); // original method of process class
        }
    }
