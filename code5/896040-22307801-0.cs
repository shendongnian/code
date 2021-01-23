    class Api : UserAgent
    {
        public event Action<string> SomeEvent;//TODO give better name
        public void startAttemptingWithUsername()
        {
            _shouldStop = false;
            while (!_shouldStop)
            {
                Console.WriteLine(username);
                var handler = SomeEvent;
                if (handler != null)
                    handler("asdf");
                // How would i notify AttemptingWithPasswordMessage from here?
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
