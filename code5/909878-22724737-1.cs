    using System.Text.RegularExpressions;
    
    ...
    
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var file = Regex.IsMatch(path, @"\d{2,}\2");
        if(file == true)
        {
             // Do Something
        }
