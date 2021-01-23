    string line = "";
    string[] stringsperate = new string[] { "</cProgram>" };
    using (StreamReader sr = new StreamReader("C://blah.xml"))
    {
         line = sr.ReadToEnd();
         Console.WriteLine(line);
    }
    string text = line.Split(stringsperate, StringSplitOptions.None)[0];
    text += "</cProgram>";
    XmlDocument xd = new XmlDocument();
    xd.LoadXml(text);
    Console.Read();
