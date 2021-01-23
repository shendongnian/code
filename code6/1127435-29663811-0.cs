    public static T GetInput<T>(string prompt)
    {
        //some stuff about printing the prompt
        string input = Console.ReadLine();
        return Convert.ChangeType(input, typeof(T));
    }
