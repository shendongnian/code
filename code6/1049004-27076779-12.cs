    void Main()
    {
      Console.WriteLine(GetName(0)); // NormalStop
      Console.WriteLine(GetName(1)); // Class not found
      Console.WriteLine(GetName(ErrorCode.Unknown)); // Unknown
    }
