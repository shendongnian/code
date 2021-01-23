    public class Example
    {
        public void Foo()
        {
            Bar();
        }
    
        private void Bar([CallerMemberName] string caller = null)
        {
             Console.WriteLine(caller); //Writes "Foo"
        }
    }
