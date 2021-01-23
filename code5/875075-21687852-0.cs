    public void WriteXML(){
        var xmlDoc = XElement.Load("reminds.xml");
        string nowaData = dataData.Text.ToString();
        string nowyOpis = tblOpis.Text.ToString();
        var nowePrzypo = new XElement("przypom",
            new XElement("data", nowaData),
            new XElement("opis", nowyOpis));
        ***xmlDoc.Root.Add(nowePrzypo);***
        xmlDoc.Save("reminds.xml");
  }
