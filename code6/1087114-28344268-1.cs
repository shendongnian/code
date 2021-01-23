        var subStringTwice = subString + subString;
        while (s.Contains(subStringTwice))
        {
            s = s.Replace(subStringTwice, subString);
        }
