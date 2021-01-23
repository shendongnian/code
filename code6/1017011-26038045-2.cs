    foreach (Match match in matches)
            {
                string col1 = match.Groups["col1"].Value;
                string col2 = match.Groups["col2"].Value;
                string col3 = match.Groups["col3"].Value;
                System.Console.WriteLine(col1 + "\t|\t" + col2 + "\t|\t" + col3);
            }
