    public static void Main(string[] args)
    {
        Console.WriteLine("Location is ({0},{1})", 4, 7);
        WriteWithTimestamp("Location is ({0},{1})", 4, 7);
    }
    public static void WriteWithTimestamp(params object[] parameters)
    {
        Console.Write(DateTime.Now.ToString());
        Console.Write(": ");
        var parameterTypes = parameters.Select(p => p.GetType()).ToArray();
        var writeLine = typeof(Console).GetMethod("WriteLine", parameterTypes);
        writeLine.Invoke(null, parameters);
    }
