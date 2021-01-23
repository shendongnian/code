    string textToChange = "WARD_VS_VITAL_SIGNS";
    System.Text.StringBuilder resultBuilder = new System.Text.StringBuilder();
    
    foreach(char c in textToChange)
    {
        // Only keep letters and digits
        if(Char.IsLetterOrDigit(c))
        {
            resultBuilder.Append(c);
        }
    }
    string result = resultBuilder.ToString();
    // Make result string all lowercase, because ToTitleCase does not change all uppercase correctly
    result = result.ToLower();
    // Creates a TextInfo based on the "en-US" culture.
    TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
    result = myTI.ToTitleCase(result)
