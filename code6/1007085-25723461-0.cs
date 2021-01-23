    foreach (var x in xdoc.Descendants("annotation").ToList())
    {
        foreach (var el in x.Descendants("image").ToList())
        {
            if (el.Attribute("location").Value == fName &&
                x.Attribute("eventID").Value == eventID.Text)
            {
                el.Remove();
            }
        }
    }
