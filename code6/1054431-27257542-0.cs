    int value;
    foreach(var s in stringList)
    {
        if(int.TryParse(s, out value))
        {
            // s was a number, the parsed result is in value
        }
        else
        {
            // s was something else
        }
    }
