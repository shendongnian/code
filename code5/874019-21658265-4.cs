    XDocument doc = XDocument.Load("data.xml");
    var fiveItems = doc.Elements("data")
    .Select(x=> new{Date = DateTime.Parse(x.Attribute("date").Value.TrimEnd("CET".ToCharArray()))
                     ,Volume = int.Parse(x.Attribute("volume").Value)})
    .GroupBy(x=>x.Date.Date)
    .Select(x=> new{ Date = x.Key, Volume = x.Average(k=>k.Volume)})
    .OrderByDescending(x=>x.Date)
    .Take(5);
