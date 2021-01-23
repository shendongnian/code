    IEnumerable<Guid> uids = root.Descendants("Photo")
       .Where(e => XmlConvert.ToDateTime(e.Element("Date").Value, XmlDateTimeSerializationMode.Utc) < DateTime.Now.AddMonths(-6))
           .Select(e => Guid.Parse(e.Attribute("UID").Value))
           .ToList();
   
