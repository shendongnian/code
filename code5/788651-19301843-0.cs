    using System.Text.RegularExpressions;  //add this using
    foreach (string line in lines)
    {
        string[] tokens = Regex.Split(line.Trim(), " +");
        int seq = 0;
        DateTime dt;
        if(tokens.Length > 0 && int.TryParse(tokens[0], out seq))
        { 
            // parse this line - 1st type
        }
        else if (tokens.Length > 0 && DateTime.TryParse(tokens[0], out dt))
        {
            // parse this line - 2nd type
        }
        // else - don't parse the line
    }
