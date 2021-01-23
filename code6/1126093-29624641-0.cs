    string line;
    string pattern = "([0-9]{1,2})/([0-9]{2})/([0-9]{4})";
    string replacement = "$3 $2 $1";
    
    System.IO.StreamReader file = new System.IO.StreamReader(path);
    while ((line = file.ReadLine()) != null)
    {
       Regex rgx = new Regex(pattern);
       // Split input value and if the first part's length is 1 then change your replacement pattern and add 0 before $1
       var parts = line.Split(new[] {'/'});
       if (parts[0].Length == 1)
        {
            replacement = "$3 $2 0$1";
        }
           
       string result = rgx.Replace(line, replacement);
       all += result + "\r\n";
       richTextBox1.Text += result + "\r\n";
    }
