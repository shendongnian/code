    private static List<string> ReadFile(string FileName)
      {
          List<string> commands = new List<string>();
          StringBuilder command = new StringBuilder();
          if (!File.Exists(FileName))
          {
              Console.WriteLine("File not found");
              return null;
          }
          
          foreach (var line in File.ReadLines(FileName))
          {
              if (!String.IsNullOrEmpty(line))
              {
                  command.Append(line + "\n");
              }
              else
              {
                  commands.Add(command.ToString());
                  command.Clear();
              }
          }
          commands.Add(command.ToString());
          return commands;
      }
