    dato = new StringBuilder();
    foreach (string line in lines)
    {
         string line1 = line;
        line1 = line1.Replace("\n", " ");
        for (int i = 0; i < line1.Count(); i++)
        {
            if (!line1[i].Equals(""))
            {
                dato.Append(line1[i] + "");
            }
        }
        Console.WriteLine(dato);
    }
    File.WriteAllText(filDat2, dato.ToString());
