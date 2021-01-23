         XDocument doc = XDocument.Load("D:\\tmp.xml");
         List<XElement> elements = new List<XElement>();
         foreach (XElement cell in doc.Element("Actions").Elements("Action"))
         {
            if (cell.Element("ActionDate") == null)
            {
               elements.Add(cell);
            }
         }
         foreach (XElement xElement in elements)
         {
            xElement.Remove();
         }
         doc.Save("D:\\tst.xml");
