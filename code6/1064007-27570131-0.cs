    const int NOTCALLED = 0;
    const int CALLED = 1;
    static int _state = NOTCALLED;
    static readonly object _lock = new object();
    //...
    static void InterlockedCheck(string thread)
    {
        lock (_lock)
        {
            Console.WriteLine("Enter thread [{0}], state [{1}]", thread, _state);
            if (_state == NOTCALLED)
            {
                Console.WriteLine("Setting state on T[{0}], state[{1}]", thread, _state);
                _state = CALLED;
            }
            Console.WriteLine("Exit from thread [{0}] state[{1}]", thread, _state);
        }
    }
