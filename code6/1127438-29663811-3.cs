    public static T GetInput<T>(string prompt)
    {
        //some stuff about printing the prompt
        string input = Console.ReadLine();
        return (T)Convert.ChangeType(input, typeof(T));
    }
