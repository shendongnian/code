    string name_var = "Steve"; 
   
    string line = ReadLineFromFile();
    line = line.Replace("\\n", Environment.NewLine);
    string formatted_line = String.Format(line, name_var);
