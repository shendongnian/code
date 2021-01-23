    public static void Main()
    {            
        string pattern = @"([^„]*?(„[^“]+?“)*)+?(?<!\b[\dA-Z])([?!]|[.]{1,3})";
        string input = "Šios sutarties sąlygos taikomos „Microsoft. Hotmail“, „Microsoft. SkyDrive“, „Microsoft“ abonementui.";            
        var matches = Regex.Matches( input, pattern );
        foreach( Match match in matches )
        {
            Console.WriteLine(match.Value.Trim());
        }
    }   
