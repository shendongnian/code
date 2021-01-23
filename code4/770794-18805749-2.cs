         List<string> lines = loadedLines.ToList();
         lines.Add("00009VAL09");
         lines[4] = "00008XXXXX";
         File.WriteAllLines(path, lines);
         
