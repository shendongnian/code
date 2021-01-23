    static List<CRMIssueHeader> issueheader=new List<CRMIssueHeader>();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            if (!Page.IsPostBack)
            { 
                issueheader = _CRMService.CRMTRN02_GetIssueHeader();
            }
        }
    protected void btnOK_Click(object sender, EventArgs e)
    {
      List<CRMIssueHeader> IHeader = new List<CRMIssueHeader>();
            IHeader = issueheader;
           //_CRMService = new CRMService();
            //issueheader  = _CRMService.CRMTRN02_GetIssueHeader();
            if (!chknew.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 0).ToList();
            if (!chkWIP.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 1).ToList();
            if (!chkFixed.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 2).ToList();
            if (chkAccepted.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 3).ToList();
            if (chkClarification.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 4).ToList();
            if (chkCancel.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 5).ToList();
            if (chkOnHold.Checked)
                IHeader = IHeader.Where(obj => obj.IssueStatus != 6).ToList();
            if (ddlCustomers.SelectedValue.ToString() != "All")
                IHeader = IHeader.Where(obj => obj.CustomerCode == ddlCustomers.SelectedValue.ToString()).ToList();
            if (txtFrom.Text.Length != 0 && txtTo.Text.Length != 0)
                IHeader = IHeader.Where(obj => obj.ReportedOn >= DateTime.Parse(txtFrom.Text) && obj.ReportedOn <= DateTime.Parse(txtTo.Text)).ToList();
            else if (txtFrom.Text.Length != 0 && txtTo.Text.Length == 0)
                IHeader = IHeader.Where(obj => obj.ReportedOn >= DateTime.Parse(txtFrom.Text)).ToList();
            else if (txtFrom.Text.Length == 0 && txtTo.Text.Length != 0)
                IHeader = IHeader.Where(obj => obj.ReportedOn <= DateTime.Parse(txtTo.Text)).ToList();
            else ;
}
 
