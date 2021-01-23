    public void SetProperties(System.Xml.Linq.XNode properties)
    {
         var element = properties as XElement;
         int tempFor1 = 0;
         if (element != null)
         {
            tempFor1 = element.Elements().Count();
         }
    }
