    private void FetchAllJobStatus(int regionID)
    {
        OleDbConnection con = new OleDbConnection(Constring);
        String strQu1;
        strQu1 = "SELECT LOGPATH, TWSID FROM JOB_DETAILS_TEST WHERE REGIONID = " + regionID + " ORDER BY TWSID";
        OleDbDataAdapter dapt1 = new OleDbDataAdapter(strQu1, con);
        DataTable dt1 = new DataTable();
        dapt1.Fill(dt1);
        DataSet ds = new DataSet(); // Move this out
        DataTable dt = new DataTable("MyTable"); 
        dt.Columns.Add(new DataColumn("yourColumnName",typeof(int))); // Create columns as you want (your structure)
        dt.Columns.Add(new DataColumn("yourColumnName2", typeof(string)));
        foreach (DataRow row in dt1.Rows)  // Now inside foreach create row and add it to  the table
        {
            string twsIDName = row.ItemArray[1].ToString();
            string startTime = GetStartTime(row.ItemArray[0].ToString(), int.Parse(twsIDName));
            string endTime = GetEndTime(row.ItemArray[0].ToString(), int.Parse(twsIDName));
            DateTime dat1 = DateTime.Parse(startTime);
            DateTime dat2 = DateTime.Parse(endTime);
            string endingTime;
            if (endTime == string.Empty || endTime == null || dat2 < dat1)
            {
                endingTime = "";
            }
            else
            {
                endingTime = endTime.Remove(0, 3).ToString();
            }
            string startingTime = startTime.Remove(0, 3).ToString();
            String strQu2;
            strQu2 = "SELECT JOBNAME, TWSID, HIGHPRIORITY, DAY, TIME, '"+ startingTime + "' as StartTime, '"+ endingTime + "' as EndTime FROM JOB_DETAILS_TEST WHERE TWSID = " + int.Parse(twsIDName) + " AND REGIONID = " + regionID + " ORDER BY JOBNAME";
            OleDbDataAdapter dapt2 = new OleDbDataAdapter(strQu2, con);
            // dapt2.Fill(ds, "dt2");
            DataRow dr = dt.NewRow(); // create row
            dr["yourColumnName"] = // fill these
            dr["yourColumnName2"] = // fill these
            dt.Rows.Add(dr); // add row to dt
        }
        ds.Tables.Add(dt); // add table to your dataset
        dgJobStatusAll.AutoGenerateColumns = true;
        dgJobStatusAll.DataSource = ds;
        dgJobStatusAll.DataMember = "dt2";
    }
