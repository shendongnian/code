    public class Something : ISomething
    {
        public void DoSomething() { ... }
        // Add this method
        public void ProcessSomething(Something other) {
            ISomething byInterface = other; // This is legal
            // Now do something with byInterface
        }
    }
