    string ParseText(string input)
    {
        // Replace quotes with nothing at all...
        var noQuotes = input.Replace("\"", "");
        // Replace commas with, I dunno, "whatever you want"... 
        // If you want to just get rid of the commas, you could use "",
        // or if you want a space, " "
        return input.Replace("," "whatever you want");
    }
