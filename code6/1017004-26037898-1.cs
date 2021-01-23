    string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    List<Data> allData = new List<Data>();
    foreach (string line in lines)
    {
        string token1 = null, token2 = null;
        DateTime dt;
        int firstColonIndex = line.IndexOf(": ");
        if (firstColonIndex >= 0)
        {
            firstColonIndex += 2; // start next search after first token to find DateTime
            token1 = line.Remove(firstColonIndex);
            int indexOfMinus = line.IndexOf(" - ", firstColonIndex);
            if (indexOfMinus >= 0)
            {
                string datePart = line.Substring(firstColonIndex, indexOfMinus - firstColonIndex);
                if (DateTime.TryParseExact(datePart, "MM/dd/yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                {
                    indexOfMinus += 3;  // start next search after DateTime to get last token
                    token2 = line.Substring(indexOfMinus);
                    Data d = new Data { Token1 = token1, Token2 = token2, Date = dt };
                    allData.Add(d);
                }
            }
        }
    }
