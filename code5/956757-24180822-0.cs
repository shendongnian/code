    foreach (string line in lines)
    {
         if (!string.IsNotNullOrEmpty(line))
         {
              if (line[0] != "-" && line[0] != " " && line[0] != "\r")
              {
                   list_of_programs.Add(line);
              }
         }
     }
