    Regex EAN8 = new Regex(@"\b(?:[Ee][Aa][Nn]_?)?(\d{8})\b");
    Regex EAN13 = new Regex(@"\b(?:[Ee][Aa][Nn]_?)?(\d{13})\b");
    using (StreamReader sr = new StreamReader(@"....txt"))
        {
            string currentLine;
            while ((currentLine = sr.ReadLine()) != null)
            {
                Match m13 = EAN13.Match(currentLine);
                Match m8 = EAN8.Match(currentLine);
                if (m8.Success)
                {
                    lista_EAN8.Add(m8.Groups[1].Value);
                }
                if (m13.Success)
                {
                    lista_EAN13.Add(m13.Groups[1].Value);
                }
            }
        }
