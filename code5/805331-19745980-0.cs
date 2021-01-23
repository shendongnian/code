    public static byte[] ParseByteArrayFromInput(string input)
    {
        var splitInput = input.Split(','); //Splits the input into a string array. The "split" happens on the comma character.
        var convertToBytes = splitInput.Select(s => //for each of these strings in the split input...
        {
            var trim = s.Trim(); //Trim away any whitespace surrounding the number.
            return byte.Parse(trim); //Parse the trimmed string into a byte.
        });
        return convertToBytes.ToArray();//Convert it into an array.
    }
