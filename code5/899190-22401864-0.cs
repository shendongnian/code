    public void ProcessDataTable(DataSet _ds)
    {
        if (Session["GeoExpAllRec"] == null)
        {
            //Fetch all records here and add it to a datatable i.e. "select des_ID, description from geo_exemption"
            //Then Add the datatable to the session variable Session["GeoExpAllRec"]
        }
        _ds.Tables[0].Columns.Add(new DataColumn("Descpition", typeof(string)));
        int countryId = -1;
        string des_ID = string.Empty;
        string geo = string.Empty;
        foreach (DataRow row in _ds.Tables[0].Rows)
        {
            if (row["des_ID"] != DBNull.Value)
                des_ID = row["des_ID"].ToString();
            if (!string.IsNullOrEmpty(des_ID))
            {
                if (countryId == 12 || countryId == 13)
                    geo = "NA";
                else if ((countryId == 10 || countryId == 11))
                    geo = "LA";
                else
                    geo = "EMEA";
                //Instead of calling "GetDes" function which will hit the database
                //Type-cast the session variable Session["GeoExpAllRec"] to datatable i.e. (Session["GeoExpAllRec"] as DataTable)
                //Fire a LINQ query on the datatable to get the desired Description like below
                //row["Descpition"] = GetDes(geo, des_ID);
                DataTable dt = (Session["GeoExpAllRec"] as DataTable);
                row["Descpition"] = dt.AsEnumerable().Where(r => r.Field<string>("des_ID") == des_ID).First()["description"];
            }
            else { row["ExemptionDes"] = string.Empty; }
        }
    }
