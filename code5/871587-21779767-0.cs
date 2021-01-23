    XNamespace ns = xDocument.Root.Attribute("xmlns").Value;
    
    List<CX_ITEMLIST> sList =
        (from e in XDocument.Load(param.FileName).Root.Elements(ns + "itemEntry")
         select new CX_ITEMLIST
         {
             TITLE = (string)e.Element(ns + "title"),
             YEAR = (string)e.Element(ns + "year"),
             ITEMNAME = (string)e.Element(ns + "itemname"),
             CATRYLIST =
             (
                 from p in e.Elements(ns + "categorylist").Elements(ns + "categories")
                 select new CATLIST
                 {
                     IDTYPE = (string)p.Element(ns + "categoryid"),
                     IDNUMBER = (string)p.Element(ns + "categoryName")
                 }).ToList()
         }).ToList();
