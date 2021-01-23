    public IEnumerable<SomeObject> ExtractFromXml(XmlReader rdr)
    {
      using(rdr)
        while(rdr.Read())
          if(rdr.NodeType == XmlNodeType.Element && rdr.LocalName = "thatElementYouReallyCareAbout")
          {
             var current = /*Code to create a SomeObject from the XML goes here */
             yield return current;
          }
    }
