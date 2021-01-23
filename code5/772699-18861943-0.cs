     StreamReader reader = new StreamReader(@"C:\Users\vemarajs\Desktop\HL7\Ministry\HSHS.txt");
     File.AppendAllText(@"C:\Users\vemarajs\Desktop\Test\OBX.txt", OBX1 + Environment.NewLine);
     List<string> list = new List<string>();
     using (reader)
     {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
           list.Add(line);
           if (line.StartsWith("OBX|1") == true)
           {
              File.AppendAllText(@"C:\Users\vemarajs\Desktop\Test\test.txt", txt+Environment.NewLine);
           }
           else if (line.StartsWith("OBX|") == true)
           {
              // Don't write
           }
           else
           {
              File.AppendAllText(@"C:\Users\vemarajs\Desktop\Test\test.txt", line + Environment.NewLine);
           }
