    string textToChange = "WARD_VS_VITAL_SIGNS";
    System.Text.StringBuilder resultBuilder = new System.Text.StringBuilder();
    
    foreach(char c in textToChange)
    {
        // Replace anything, but letters and digits, with space
        if(!Char.IsLetterOrDigit(c))
        {
            resultBuilder.Append(" ");
        }
        else 
        { 
            resultBuilder.Append(c); 
        }
    }
    string result = resultBuilder.ToString();
    // Make result string all lowercase, because ToTitleCase does not change all uppercase correctly
    result = result.ToLower();
    // Creates a TextInfo based on the "en-US" culture.
    TextInfo myTI = new CultureInfo("en-US",false).TextInfo;
    result = myTI.ToTitleCase(result).Replace(" ", String.Empty);
