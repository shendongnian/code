     MXWO proxy = new MXWO();
            MXWO_WORKORDERType[] wo_results;
            MXWO_WORKORDERType[] wo_new = new MXWO_WORKORDERType[1];
            DateTime creationDateTime = new DateTime();
            WebServiceUseCases.com.cts.ctsinpunvemscoe_MXWO.MXStringQueryType[] queryName = new com.cts.ctsinpunvemscoe_MXWO.MXStringQueryType[1];
            queryName[0] = new com.cts.ctsinpunvemscoe_MXWO.MXStringQueryType();
            queryName[0].Value = "";
            WebServiceUseCases.com.cts.ctsinpunvemscoe_MXWO.MXDomainQueryType[] queryStatus = new com.cts.ctsinpunvemscoe_MXWO.MXDomainQueryType[1];
            queryStatus[0] = new com.cts.ctsinpunvemscoe_MXWO.MXDomainQueryType();
            queryStatus[0].Value = "";
            MXWOQueryType query = new MXWOQueryType();
            query.WORKORDER = new MXWOQueryTypeWORKORDER();
            if (txtBoxWOName.Text != "")
            {
                queryName[0].Value = txtBoxWOName.Text;
                query.WORKORDER.WONUM = queryName;
            }
            if (cmBoxStatus.SelectedIndex != 0)
            {
                queryStatus[0].Value = cmBoxStatus.SelectedItem.ToString();
                query.WORKORDER.STATUS = queryStatus;
            }
    
            proxy.Url = "http://<server name>:<port>/meaweb/services/MXWO";
    
            bool creationDateTimeSpecified = false;
            string language = "en";
            string transLanguage = "en";
            string messageID = "NoDef";
            string maximoVersion = "NoDef";
            bool uniqueResult = false;
            string maxItems = "2000";
            string rsStart = "0";
            string rsCount = "NoDef";
            string rsTotal = "NoDef";
    
            wo_results = proxy.QueryMXWO(query, ref creationDateTime, ref creationDateTimeSpecified, ref language,
            ref transLanguage, ref messageID, ref maximoVersion, uniqueResult, maxItems, ref rsStart, out rsCount, out rsTotal);
