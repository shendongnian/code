    var lines = File.ReadAllLines(pathToImportFile);
    var sb = new StringBuilder();
    var separator = ","; // use a comma as field delimiter
    foreach (string line in lines)
    {
        if (String.IsNullOrEmpty(line))
            sb.AppendLine(""); // convert empty lines into line feeds
        else
            sb.AppendFormat("\"{0}\"{1}", line, separator); // put quotes around the field to avoid problems with nested separators
    }
    var engine = new FileHelperEngine<MyClass>();
    engine.ReadString(sb.ToString());
