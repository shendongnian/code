    var doc = XDocument.Load(@"C:\Users\IT-Administrator\Desktop\2014-01-07_Middlesex.xml");
    List<string> IncidentsSeen = new List<string>();
    foreach (var item in doc.Element("Incidents").Elements("Incident"))
    {
        var EntryDate = item.Element("Comment").Value;
        if (IncidentsSeen.Contains(EntryDate))
        {
            item.Remove();
        }
        else
        {
            IncidentsSeen.Add(EntryDate);
        }
    }
