    public static Degree Parse(string input)
    {
       Degree parsedDegree = new Degree();
       string[] seperatedStrings = input.Split(new char[] {'°', '\''});
       parsedDegree.degrees = seperatedStrings[0];
       parsedDegree.minutes = seperatedStrings[1];
       parsedDegree.seconds = seperatedStrings[2];
       return parsedDegree;
    }
