    DataTable dt = new DataTable();
    dt.Columns.Add("ID");
    dt.Columns.Add("Türkçe");
    dt.Columns.Add("English");
    //Load xml
        XDocument xdoc = XDocument.Load("E:/MyApps/TestDemo/Language.xml");
  
        //Run query
        var lv1s = from lv1 in xdoc.Descendants("control")
                   select new
                   {
                       id = lv1.Attribute("id").Value,
                       turkce = lv1.Attribute("turkce").Value,
                       english = lv1.Attribute("english").Value
                   };
        foreach (var lv1 in lv1s)
        {
            dt.Rows.Add(lv1.id, lv1.turkce, lv1.english);
        }
        gv.DataSource = dt;
        gv.DataBind();
