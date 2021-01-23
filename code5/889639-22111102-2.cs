    public static void WriteEnums<T>(List<T> enums)
    {
        var streamWriter = new StreamWriter("test.txt");
    
        foreach (var myEnum in enums)
        {
            streamWriter.WriteLine(myEnum);
        }
    
        streamWriter.Close();
    }
