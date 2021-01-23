            Label1.Text = Session["Location"].ToString();
            int Loc = Convert.ToInt32(Label1.Text);
    
            Label2.Text = Session["CurrentMonthStart"].ToString();
            DateTime dt = Convert.ToDateTime(Label2.Text);
    
            Label3.Text = Session["MonthCurrent"].ToString();
            Label4.Text = Session["MonthPrevious"].ToString();
    
           //EXECCUTE the procedure here
            using(SqlCommand cmd = new SqlCommand("spName",con)
            {
               cmd.CommandType = CommandType .StoredProcedure;
               cmd.Parameters.AddwithValue("@Location", LOC);
               cmd.Parameters.AddwithValue("@CurrentMonthStart ",   Label3.Text);
               cmd.Parameters.AddwithValue("@date ",   dt);
               cmd.Parameters.AddwithValue("@CurrentMonthStart ",   Label4.Text);
           
              cmd.ExecuteNonQuery();
            } 
            report.Load(Server.MapPath("MonthlySalesReport.rpt"));
    
            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.ReuseParameterValuesOnRefresh = true;
    
            con.Close();
