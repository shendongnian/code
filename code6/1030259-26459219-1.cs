    protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    bool isValid = true;
    
                    // Setting ReportName
                    string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();
    
                    // Setting Report Data Source     
                    var rptSource = System.Web.HttpContext.Current.Session["rptSource"];
    
                    if (string.IsNullOrEmpty(strReportName)) // Checking is Report name provided or not
                    {
                        isValid = false;
                    }
    
    
                    if (isValid) // If Report Name provided then do other operation
                    {
                        rd = new ReportDocument();
                        if (Session["ReportDocument"] != null)
                        {
                            rd = Session["ReportDocument"] as ReportDocument;
                            rd.Load(strReportName);
    
                            CrystalReportViewer1.ReportSource = rd;
                        }
                        else
                        {                        
                            string stringReportPath = strReportName;
                            //Loading Report
                            rd.Load(stringReportPath);
    
                            // Setting report data source
                            if (rptSource != null && rptSource.GetType().ToString() != "System.String")
                                rd.SetDataSource(rptSource);
                            Session["ReportDocument"] = rd;
    
                            CrystalReportViewer1.ReportSource = rd;
                        }
                        Session["ReportName"] = "";
                        Session["rptSource"] = "";
                    }
                    else
                    {
                        Response.Write("<H2>Nothing Found; No Report name found</H2>");
                    }
                }
                else
                {
                    doc=new ReportDocument();
                    doc = (ReportDocument)Session["ReportDocument"];
                    CrystalReportViewer1.ReportSource = doc;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
       
    
         finally
           {
             Dispose();
           }
    
        }
