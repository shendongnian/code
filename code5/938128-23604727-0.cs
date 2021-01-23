    // hide viewer, show progress
    CrystalReportViewer1.Visible = false;
    pictureBoxProgress.Visible = true;
    // start thread
    (new Thread(() => {
        // your code
        SqlCommand cmdrslt = new SqlCommand("rptdeptwisevisitor", con.connect);
        cmdrslt.CommandType = CommandType.StoredProcedure;
        cmdrslt.Parameters.Add("@startDate", SqlDbType.NVarChar, 50, ParameterDirection.Input).Value = frmdateval;
        cmdrslt.Parameters.Add("@endDate", SqlDbType.NVarChar, 50, ParameterDirection.Input).Value = Todateval;
        SqlParameter tvp1 = cmdrslt.Parameters.AddWithValue("@Dept", DepTable);
        tvp1.SqlDbType = SqlDbType.Structured;
        tvp1.TypeName = "dbo.Dept";
        da.SelectCommand = cmdrslt;
        da.Fill(ds);
        DeptWiseRpt rpt = new DeptWiseRpt();
        if ((ds.Tables(0).Rows.Count > 0)) {
            rpt.SetDataSource(ds.Tables(0));
            rpt.SetParameterValue("frmd", setparmstartd);
            rpt.SetParameterValue("tod", setparmendd);
            // controls operations require invoke
            BeginInvoke(() => {
                CrystalReportViewer1.ReportSource = rpt;
                pictureBoxProgress.Visible = false;
                CrystalReportViewer1.Visible = true;
            });
        }
    })).Start();
