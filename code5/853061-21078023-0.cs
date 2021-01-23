    var file = new System.IO.StreamReader(@"c:\test.csv");
    while ((line = file.ReadLine()) != null)
    {
        string[] words = line.Split(';');
        DateTime dt;
        if(DateTime.TryParse(words[1], new CultureInfo("de-DE"), DateTimeStyles.None, out dt) && dt == DateTime.Today)
        {
            mail.Body += line + Environment.NewLine;
            counter++;
        }
    }
