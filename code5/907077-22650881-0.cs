     public static class ReportParameters
     {
        private static ReportParameter[] _parameters= null;
        public static ReportParameter[] Parameters
        {
             get { return _parameters; }
             set { _parameters = value; }
          }
          private static String _ReportName = String.Empty;
          public static String ReportName
          {
             get { return _ReportName; }
             set { _ReportName = value; }
          }
       }
    protected void SendToRenderReport()
    {
        ReportParameter[] parameters = new ReportParameter[3];
        parameters[0] = new ReportParameter("StartDate", txtStartDate.Text);
        parameters[1] = new ReportParameter("EndDate", txtEndDate.Text);
        parameters[2] = new ReportParameter("DealerID", ddlDealer.SelectedValue);    
                
        //Set Report Parameters which you assigned above
        ReportParameters.Parameters = parameters;
    
        //Set Report Name and redirect to report page
        ReportParameters.ReportName = "/ReportFolder/ReportName";
        Response.Redirect("Reports.aspx");
    }
