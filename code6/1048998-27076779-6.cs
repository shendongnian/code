    void Main()
    {
      Console.WriteLine(GetName(0)); // NormalStop
      Console.WriteLine(GetName(1)); // Invalid ErrorCode
      Console.WriteLine(GetName(ErrorCode.Unknown)); // Unknown
    }
