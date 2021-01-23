    // Extention method to simplify:
    public static string GetNumbersFromPos(this string line, int nrToSkip)
    {
        return new string(line.Skip(nrToSkip)
                                .TakeWhile(c => Char.IsNumber(c))
                                .ToArray());
    }
    // Assume you get this from your array:
    var eachLine = "Previous errors were for Test id '1234567' Error id '12345678'";
    // Find nr of chars to skip
    var beforeFirstId = eachLine.IndexOf("id '") + 4;
    var beforeSecondId = eachLine.IndexOf("id '", beforeFirstId) + 4;
    // Now use the extention method to get the two number-strings:
    var firstId = eachLine.GetNumbersFromPos(beforeFirstId);
    var secondId = eachLine.GetNumbersFromPos(beforeSecondId);
