    public JsonResult TopPlayedInVenueList1(string sorting, string StartDate = "", string EndDate = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
    {
        try
        {
            if (Request.IsAuthenticated == true)
            {
                string Path = @"C:\\5Newwithdate-1k.xls";
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source= '" + Path + "';Extended Properties=" + (char)34 + "Excel 8.0;IMEX=1;" + (char)34 + "");
                OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", con);
                con.Close();
                System.Data.DataTable data = new System.Data.DataTable();
                da.Fill(data);
                List<TopPlayed> daa = new List<TopPlayed>();
                foreach (DataRow p in data.Rows)
                {
                    TopPlayed top = new TopPlayed()
                    {
                        TrackID = Convert.ToInt32(p.Field<double>("TrackID")),
                        Date = p.Field<DateTime>("DateTimes"),
                        TrackName = p.Field<string>("TrackName"),
                        ArtistName = p.Field<string>("ArtistName"),
                        Times = Convert.ToInt32(p.Field<double>("Times"))
                    };
                    
                    //Don't sort inside your foreach!
                    //if (sorting != null)
                    //{
                    //    daa.OrderBy(i => i.Date);
                    //}
                    daa.Add(top);
                }
                //var listOrder = daa.OrderBy(i => i.Date).ToList().Where(i => i.Date >= Convert.ToDateTime(StartDate) && i.Date <= Convert.ToDateTime(EndDate));
                //Don't run a Where after Orderby, probably you're fine...but not sure its guaruanteed, oh and you probably don't want to sort here either
                //I'm also a little surprised that the Convert statements in there aren't causing runtime errors..
                var listOrder = daa.Where(I => i.Date >= Convert.ToDateTime(StartDate) && i.Date <= Convert.ToDateTime(EndDate)).ToList();
                //you don't need to convert .ToList() to get .Count
                if (jtStartIndex + 150 > listOrder.ToList().Count)
                {
                    int val = listOrder.ToList().Count - jtStartIndex;
                    jtPageSize = val;
                }
                //This is the list that you actually return. This is where you sort your list
                var newlist = listOrder.OrderBy(i => i.Date).ToList().GetRange(jtStartIndex, jtPageSize);
                return Json(new { Result = "OK", Records = newlist, TotalRecordCount = listOrder.ToList().Count });
