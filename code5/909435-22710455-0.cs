    string content = "";
    using (var reader = new StreamReader("C:\\temp\\abc.txt"))
    {
        content = reader.ReadToEnd();
    }
    if (!string.IsNullOrEmpty(content))
    {
        var value = content.Split('\n').OrderByDescending(y => y.Split('\t').Count()).Take(1);
    }
