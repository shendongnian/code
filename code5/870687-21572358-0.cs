    XElement root = null;
    root = XElement.Load(new XmlTextReader(path));
    if (root != null)
    {
        XNamespace ns = "http://schemas.microsoft.com/practices/2010/unity";
        var registers = root.Element(ns + "unity").Element(ns + "container").Descendants(ns + "register");
        if (registers.Count() > 0)
        {
            var tipList = registers.Select(x => x.Attribute("type").Value);
            var mapToList = registers.Select(x => x.Attribute("mapTo").Value);
            List<string> listresult = new List<string>();
            List<string> listresultm = new List<string>();
            foreach (string tpl in tipList)
            {
                int end = tpl.IndexOf(',');
                int start = tpl.LastIndexOf('.', (end == -1 ? tpl.Length - 1 : end)) + 1;
                string result = tpl.Substring(start, (end == -1 ? tpl.Length : end) - start);
                listresult.Add(result);
            }
            foreach (string mpl in mapToList)
            {
                int endm = mpl.IndexOf(',');
                int startm = mpl.LastIndexOf('.', (endm == -1 ? mpl.Length - 1 : endm)) + 1;
                string resultm = mpl.Substring(startm, (endm == -1 ? mpl.Length : endm) - startm);
                listresultm.Add(resultm);
            }
            int maxLenList = Math.Max(listresult.Count, listresultm.Count);
            for (int i = 0; i < maxLenList; i++)
            {
                if (i < listresult.Count && i < listresultm.Count)
                {
                    _obsCollection.Add(new Tuple<string, string>(listresult[i], listresultm[i]));
                }
                else if (i >= listresult.Count)
                {
                    _obsCollection.Add(new Tuple<string, string>(string.Empty, listresultm[i]));
                }
                else if (i >= listresultm.Count)
                {
                    _obsCollection.Add(new Tuple<string, string>(listresultm[i], string.Empty));
                }
            }
        }
    }
