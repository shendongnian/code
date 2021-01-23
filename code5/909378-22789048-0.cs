    public JsonResult BilingReportList()
    {
        try
        {
            if (Request.IsAuthenticated == true)
            {
                string Path = @"C:\\5Newwithdate.xls";
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= '" + Path + "';Extended Properties=" + (char)34 + "Excel 8.0;IMEX=1;" + (char)34 + "");
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", con);
                System.Data.DataTable data = new System.Data.DataTable();
                da.Fill(data);
                con.Close();
                List<TopPlayed> daa = new List<TopPlayed>();
                foreach (DataRow p in data.Rows)
                {
                    TopPlayed top = new TopPlayed()
                    {
                        TrackID = Convert.ToInt32(p.Field<double>("ID")),
                        TrackName = p.Field<string>("Track Name"),
                        ArtistName = p.Field<string>("Artist Name"),
                        Times = Convert.ToInt32(p.Field<double>("NoOfPlays"))
                    };
                    daa.Add(top);
                }
              var newlist = daa.OrderByDescending(i => i.Times).ToList();
              return Json(new { Result = "OK", Records = newlist, TotalRecordCount = daa.Count });
            }
            return Json(new { Result = "ERROR" });
        }
        catch (Exception ex)
        {
            return Json(new { Result = "ERROR", Message = ex.Message });
        }
    }
