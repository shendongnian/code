    public DataTable parseReport(List<zapi.ClientReportResultItem> reportItems)
    {
        StringBuilder sb = new StringBuilder();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(reportItems[0].body);
        StringReader sReader = new StringReader(xmlDoc.InnerXml);
        System.Xml.Linq.XDocument d = System.Xml.Linq.XDocument.Load(sReader);
        List<_headers> headers = new List<_headers>();
        _headers header = new _headers();
        var headerXml = from r in d.Descendants("data-header")
                     .Descendants("dr")
                     .Descendants("dv")
                     select new
                     {
                         dv = r.Value,
                         dv_type = r.Attribute("type").Value
                     };
        foreach (var _val in headerXml)
        {
            header = new _headers();
            header.name = _val.dv;
            header.type = _val.dv_type;
            headers.Add(header);
        }
        //Create Data Table
        DataTable reportData = new DataTable();
        foreach (var head in headers)
        {
            if (head.type == "timestamp")
                reportData.Columns.Add(head.name, typeof(DateTime));
            else if (head.type == "int")
                reportData.Columns.Add(head.name, typeof(int));
            else if (head.type == "string")
                reportData.Columns.Add(head.name, typeof(string));
            else if (head.type == "float")
                reportData.Columns.Add(head.name, typeof(float));
            else if (head.type == "long")
                reportData.Columns.Add(head.name, typeof(long));
        }
        var data = from r in d.Descendants("data-body")
                   .Descendants("dr")
                   where r.HasAttributes == false
                   select new
                   {
                       dv = r.Elements()
                   };
        foreach (var datavalue in data)
        {
            DataRow dr = reportData.NewRow();
            for (int iCount = 0; iCount < datavalue.dv.Count(); iCount++)
            {
                dr[iCount] = datavalue.dv.ToArray()[iCount].Value;
            }
            reportData.Rows.Add(dr);
        }
        return reportData;
    }
