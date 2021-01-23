     bool Logon(ReportDocument cr, string server, string db, bool integratedSecurity, string id, string pass)
    {
        ConnectionInfo ci = new ConnectionInfo();
        SubreportObject subObj;
        ci.ServerName = server;
        ci.DatabaseName = db;
        if (integratedSecurity)
            ci.IntegratedSecurity = true;
        else
        {
            ci.IntegratedSecurity = false;
            ci.UserID = id;
            ci.Password = pass;
        }
        PassParameters();
        if (!ApplyLogon(cr, ci))
            return false;
        for (int i = 0; i < cr.ReportDefinition.ReportObjects.Count; i++)
            if (cr.ReportDefinition.ReportObjects[i].Kind == ReportObjectKind.SubreportObject)
            {
                subObj = (SubreportObject)cr.ReportDefinition.ReportObjects[i];
                if (!ApplyLogon(cr.OpenSubreport(subObj.SubreportName), ci))
                    return false;
            }
        return true;
    }
     bool ApplyLogon(ReportDocument cr, ConnectionInfo ci)
    {
        TableLogOnInfo li;
        // for each table apply connection info
        for (int i = 0; i < cr.Database.Tables.Count; i++)
        {
            li = cr.Database.Tables[i].LogOnInfo;
            li.ConnectionInfo = ci;
            cr.Database.Tables[i].ApplyLogOnInfo(li);
            // check if logon was successful
            // if TestConnectivity returns false, check
            // logon credentials
            if (TestConnectivity(cr, i))
            {
                // drop fully qualified table location
                if (cr.Database.Tables[i].Location.IndexOf(".") > 0)
                    cr.Database.Tables[i].Location = cr.Database.Tables[i].Location.Substring(cr.Database.Tables[i].Location.LastIndexOf(".") + 1);
          
         cr.Database.Tables[i].Location.Substring(cr.Database.Tables[i].Location.LastIndexOf(".") + 1);
            }
            else return false;
        }
        return true;
       }
     private static bool TestConnectivity(ReportDocument cr, int i)
    {
        bool test = false;
        try { test = cr.Database.Tables[i].TestConnectivity(); }
        catch (System.Runtime.InteropServices.COMException)
        {
            try { test = cr.Database.Tables[i].TestConnectivity(); }
            catch (System.Runtime.InteropServices.COMException)
            {
                try { test = cr.Database.Tables[i].TestConnectivity(); }
                catch (System.Runtime.InteropServices.COMException)
                { test = cr.Database.Tables[i].TestConnectivity(); }
            }
        }
        return test;
       }
      private void PassParameters()
    {
        // char[] subReportPrefix = new char[] { 'P', 'm', '-', '?' };
        foreach (ParameterField field in reportDocument.ParameterFields)
        {
            string fieldName = field.Name.TrimStart('@');//.TrimStart(subReportPrefix);
            ParameterValues p = new ParameterValues();
            string valu = clearQueryString[fieldName];//cerco in querystring
            if (!string.IsNullOrEmpty(valu))//se ho trovato in querystring ok
            {
                string[] valus = valu.Split('§');//se c'è il separatore sono values sennò è value
                if (valus.Length > 1)
                {
                    foreach (string v in valus)
                        if (p.Count == 0 || !string.IsNullOrEmpty(v))
                            p.AddValue(v);
                }
                else
                    p.AddValue(valu);
                field.CurrentValues = p;
            }
         ......
