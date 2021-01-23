    static class Program
    {
      static void Main()
      {
        throw new UserAlreadyLoggedInException("Hello");
      }
    }
    class LoginException : Exception
    {
      public LoginException(string message) : base(message)
      {
        Console.WriteLine("least derived class");
      }
    }
    class UserAlreadyLoggedInException : LoginException
    {
      public UserAlreadyLoggedInException(string message) : base(message)
      {
        Console.WriteLine("most derived class");
      }
    }
