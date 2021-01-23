    class Program
    {
        static void Main() { }
        static void DoSomething() { }
        bool ReturnFirst()
        {
            try
            {
                DoSomething();
                return true;
            }
            catch
            {
                return false;
                throw; // line 15
            }
        }
        bool ThrowFirst()
        {
            try
            {
                DoSomething();
                return true;
            }
            catch
            {
                throw;
                return false; // line 28
            }
        }
    }
