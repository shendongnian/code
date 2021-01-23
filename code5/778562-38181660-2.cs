    $('#example').dataTable({            
            "bSort": true,
            "bProcessing": true,
            "bServerSide": true,
            "bAutoWidth": true,
            "lengthMenu": [[5, 10,-1], [5, 10, "All"]],
            "sAjaxSource": "http://------/Service1.svc/gettable",
            "fnServerData": function (sSource, aoData, fnCallback) {
                var tblid = { name: "tblId", value: "test" };//pass extra param
                aoData.push(tblid);
                $.ajax({
                    "datatType": 'json',
                    "contentType": 'application/json',
                    "url": sSource,
                    "data": aoData,
                    "success": function (msg) {
                        var json = $.parseJSON(msg);
                        fnCallback(json);
                    }
                })
            },
        });
    WCF : 
    [OperationContract]
      [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle =         WebMessageBodyStyle.WrappedRequest, Method = "GET")]
            string GetTable(int iDisplayStart,
                int iDisplayLength,
                string sSearch,
                bool bEscapeRegex,
                int iColumns,
                int iSortingCols,
                int iSortCol_0,
                string sSortDir_0,
                int sEcho,
                int webSiteId,
                int categoryId, string tblId);
    public string GetTable(int iDisplayStart, int iDisplayLength, string sSearch, bool bEscapeRegex,
         int iColumns,int iSortingCols,int iSortCol_0,string sSortDir_0,int sEcho,int webSiteId,int categoryIdm,string tblId)
        {
            List<object[]> items = new List<object[]>();
            using (SqlConnection con = new SqlConnection(@"connection"))
            {
                using (SqlCommand cmd = new SqlCommand("DT_TEST", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@iDisplayStart", SqlDbType.Int).Value = iDisplayStart;
                    cmd.Parameters.Add("@iDisplayLength", SqlDbType.Int).Value = iDisplayLength;
                    cmd.Parameters.Add("@sSearch", SqlDbType.VarChar).Value = sSearch;
                    cmd.Parameters.Add("@bEscapeRegex", SqlDbType.Bit).Value = bEscapeRegex;
                    cmd.Parameters.Add("@iColumns", SqlDbType.Int).Value = iColumns;
                    cmd.Parameters.Add("@iSortingCols", SqlDbType.Int).Value = iSortingCols;
                    cmd.Parameters.Add("@iSortCol_0", SqlDbType.Int).Value = iSortCol_0;
                    cmd.Parameters.Add("@sSortDir_0", SqlDbType.VarChar).Value = sSortDir_0;
                    cmd.Parameters.Add("@sEcho", SqlDbType.Int).Value = sEcho;
                    cmd.Parameters.Add("@webSiteId", SqlDbType.Int).Value = webSiteId;
                    cmd.Parameters.Add("@categoryIdm", SqlDbType.Int).Value = categoryIdm;
                    cmd.Parameters.Add("@tblId", SqlDbType.VarChar).Value = tblId;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        List<object> rowitem = new List<object>();
                        rowitem.Add(rdr.GetString(1));
                        rowitem.Add(rdr.GetString(2));
                        rowitem.Add(rdr.GetSqlDateTime(3).ToString());
                        items.Add(rowitem.ToArray());
                    }
                }
            }
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            var result = items.ToArray();
            return serialiser.Serialize(new
            {
                sEcho,
                iTotalRecords = counr,
                iTotalDisplayRecords = count,
                aaData = result
            });
        }
