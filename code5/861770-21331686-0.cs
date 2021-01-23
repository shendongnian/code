    var items = wb.Document.GetElementById("ContentPlaceHolder1_reqTxt")
                  .Style.Split(';')
                  .Where(x => x.Contains("display"))
                  .ToArray();
    if (items.Count > 0)
    {
        string[] split = items[0].Split(':');
        if (split.Length > 1)
            Available2 = split[1];
    }
