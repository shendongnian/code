    string FormatString(string text)
    {
       // Get the last string and replace the "-" to space.
       string output = text.split('/').Last().Replace("-"," ");
       
       // convert it into title case
       output  = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(output); 
       return output;   
    }
