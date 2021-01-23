    foreach (var line1 in lines1)
    {
         if (string.IsEmptyOrWhiteSpace(line1))
         {
             break;
         }
   
         var fields1 = line1.Split(
             new Char[] { ';' },
             StringSplitOptions.RemoveEmptyEntries);
         date1.Add(fields1[0].Trim('\"'));
         if (fields1.Length > 1)
         {
             data.Add(
                 Convert.ToDouble(fields1[1].Trim('\"'),
                 CultureInfo.InvariantCulture));
         }
    }
