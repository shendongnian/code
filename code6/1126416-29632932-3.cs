    public static string FindNextVariable(StreamReader reader) {
        var i = reader.Read();
        
        bool commentBlock = false;
        string variable = "";
        while (i >= 0) {
            var c = (char)i;
            // if it's white space, toss it
            // if it's a / peek to see if the next is a * starting a comment block
            // if in a comment block, read until you get */ consecutively
            // if it's a / and not a * next, begin appending to variable until you hit white space again.
        }
        return variable;
    }
