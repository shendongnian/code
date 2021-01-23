    string line = "N12 G0 X49.000 Y30.329 Z-1.000";
    string[] splitLine = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    StringBuilder stringBuilder = new StringBuilder();
    foreach (string splitString in splitLine)
    {
        if (splitString[0] != 'Z')
        {
            // don't forget to add the spaces back
            stringBuilder.Append(splitString + " ");
        }
    }
    string finalString = stringBuilder.ToString();
