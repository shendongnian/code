    [WebMethod()]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public static string GetMemberNotesByTrip(string sEcho, int iDisplayStart, int iDisplayLength)
    {
        string rawSearch = HttpContext.Current.Request.Params["sSearch"].Trim();
        var whereClause = string.Empty;
        var filteredWhere = "1=1";
        var wrappedSearch = rawSearch.Trim();
        var Tempsb = new StringBuilder();
        Tempsb.Append("mbrid=" + MemberID);
        if (TripID != 0)
        {
            Tempsb.Append("and trpid=" + TripID);
        }
        else
            Tempsb.Append("and trpid=0");
        if (rawSearch.Length > 0)
        {
            Tempsb.Append("AND ( ISNULL(trpDate,'''') LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(" OR clrFullName LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(" OR clrPhone LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(" OR clrRelationshipToMember LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(" OR trpNote LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(" OR clrOrganization LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(" OR trpIsGrievance LIKE ");
            Tempsb.Append("'%" + wrappedSearch + "%'");
            Tempsb.Append(")");
        }
        if (Tempsb.Length > 0)
            filteredWhere = Tempsb.ToString();
        string orderByClause = string.Empty;
        orderByClause = "trpDate desc";
        StringBuilder sb = new StringBuilder();
        sb.Append(Convert.ToInt32(HttpContext.Current.Request.Params["iSortCol_0"]));
        sb.Append(" ");
        sb.Append(HttpContext.Current.Request.Params["sSortDir_0"]);
        orderByClause = sb.ToString();
        if (!String.IsNullOrEmpty(orderByClause))
        {
            orderByClause = orderByClause.Replace("0", ", trpDate ");
            orderByClause = orderByClause.Replace("1", ", clrFullName ");
            orderByClause = orderByClause.Replace("2", ", clrPhone ");
            orderByClause = orderByClause.Replace("3", ", clrRelationshipToMember ");
            orderByClause = orderByClause.Replace("4", ", clrOrganization ");
            orderByClause = orderByClause.Replace("5", ", trpIsGrievance ");
            orderByClause = orderByClause.Replace("6", ", trpNote ");
            orderByClause = orderByClause.Remove(0, 1);
        }
        else
        {
            orderByClause = "pronID ASC";
        }
        DataSet ds = clsTrip.GetTripNotesMaster(filteredWhere, orderByClause, iDisplayLength, iDisplayStart, true);
        List<clsTrip> lstTripNotesGrv = new List<clsTrip>();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            clsTrip lsttripNotes = new clsTrip();
            lsttripNotes.clrFullName = ds.Tables[0].Rows[i]["clrFullName"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["trpDate"].ToString()))
                lsttripNotes.trpDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["trpDate"].ToString());
            else
                lsttripNotes.trpDate = DateTime.MinValue;
            lsttripNotes.clrPhone = ds.Tables[0].Rows[i]["clrPhone"].ToString();
            lsttripNotes.clrRelationshipToMember = ds.Tables[0].Rows[i]["clrRelationshipToMember"].ToString();
            lsttripNotes.clrOrganization = ds.Tables[0].Rows[i]["clrOrganization"].ToString();
            if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["trpIsGrievance"].ToString()))
                lsttripNotes.trpIsGrievance = Convert.ToBoolean(ds.Tables[0].Rows[i]["trpIsGrievance"].ToString());
            else
                lsttripNotes.trpIsGrievance = false;
            lsttripNotes.trpNote = (ds.Tables[0].Rows[i]["trpNote"].ToString());
            lstTripNotesGrv.Add(lsttripNotes);
        }
        int TotalRec = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
        var result = from c in lstTripNotesGrv
                     select new[] { 
                           //Convert.ToString(c.pronID),                               
                           c.trpDate !=null && c.trpDate!=DateTime.MinValue ? string.Format("{0:MMM d, yyyy}",c.trpDate):"-",
                           c.clrFullName.ToString(),
                           c.clrPhone.ToString(),
                           c.clrRelationshipToMember.ToString(),
                           c.clrOrganization.ToString(),
                           ( Convert.ToBoolean(c.trpIsGrievance)?"Yes":"No"),
                           c.trpNote
                       };
        JavaScriptSerializer jss = new JavaScriptSerializer();
        return jss.Serialize(new
        {
            sEcho,
            iTotalRecords = TotalRec,
            iTotalDisplayRecords = TotalRec,
            aaData = result
        });
    }
