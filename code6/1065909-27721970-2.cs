    protected void Page_Load(object sender, EventArgs e)
    {
    if (!Page.IsPostBack)
    {
    Session.Remove("CR_Session");
    CboComplaintStatusFill();
    }
    else
    {
    InquiryRptViewer.ReportSource = Session["CR_Session"];
    }
    
