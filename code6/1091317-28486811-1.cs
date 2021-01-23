    static string ReplaceSuffix(string orginal, string newString)
    {
        var segments = original.Split(";".ToCharArray());
        var segments2 = segments[0].Split("@".ToCharArray());
        segments2[1] = newString;
        segments[0] = string.Join("@", segments2);
        var result = string.Join(";", segments);
        Console.WriteLine("Original String:\n{0}\nReplacement String:\n{1}, original, result);
        
        return result;
    }
