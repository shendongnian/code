      string serverName, databaseName, userId, password;
      bool integratedSecurity;
      int counter = 0;
      string line;
      // Read the file and display it line by line.
      System.IO.StreamReader file = new System.IO.StreamReader("C:\\CONNECTION.txt");
      while ((line = file.ReadLine()) != null)
      {
        if (line.Contains("Data Source"))
          serverName = line.Replace("Data Source = ", "");
        else if (line.Contains("Initial Catalog"))
          databaseName = line.Replace("Initial Catalog = ", "");
        else if (line.Contains("Integrated Security"))
          integratedSecurity = Convert.ToBoolean(line.Replace("Integrated Security = ", ""));
        else if (line.Contains("User Id"))
          userId = line.Replace("User Id = ", "");
        else if (line.Contains("Password"))
          password = line.Replace("Password = ", "");
        Console.WriteLine(line);
        counter++;
      }
      file.Close();
