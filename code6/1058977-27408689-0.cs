    foreach(var r in read)
    {
        bool isValid = false;
        foreach(var c in allowed)
        {
            // if we found a valid char set isValid to true
            if(c == r)
                isValid = true;
        }
        // if it's still false then the current char
        // doesn't match any of the allowed chars 
        // so it's invalid
        if(!isValid) 
        {
           Console.WriteLine("the string has invalid char(s)");
           break;
        }
    }
