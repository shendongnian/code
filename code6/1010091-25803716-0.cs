    var lineInfos = lines.Split(new[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)
        .Where(l => l.Trim().Length > 33)
        .Select(l => {
            string line = l.Trim();
            string Number = null;
            string Country = null;
            string Timespan = null;
            DateTime? dtNullable = null;
            DateTime dt;
            String datePart = line.Remove(17);
            if (DateTime.TryParseExact(datePart, "dd/MM/yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                dtNullable = dt;
                // extract the number from the following digits after the date:
                Number = string.Join("", line.Substring(18).TakeWhile(Char.IsDigit));
                // take the timspan at the end with a fixed length of 15 characters
                int tsLength = line.Length - 15;
                Timespan = line.Substring( tsLength ); // take from end
                // take the country from the rest 
                Country = line.Substring(18, line.Length - 15 - 18);                       
                return new { Date = dtNullable, Number, Country, Timespan };
            }
            else
                return new { Date = dtNullable, Number, Country, Timespan };
        }).Where(x => x.Date.HasValue);
    foreach (var lInfo in lineInfos)
        Console.WriteLine(lInfo.ToString());
