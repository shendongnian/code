    using System.Text.RegularExpressions;
    ...
       
    if (Regex.IsMatch(bufferincmessage, Properties.Settings.Default.REQLogin, RegexOptions.IgnoreCase))
    {
        ...
    }
    else if (Regex.IsMatch(bufferincmessage, /*some of your command1*/, RegexOptions.IgnoreCase))
    {
        ...
    }
    else if (Regex.IsMatch(bufferincmessage, /*some of your command1*/, RegexOptions.IgnoreCase))
    {
        ...
    }
