    public class DataClass
    {
        public string RMAStatus { get; set; }
    }
    private readonly Dictionary<string, string> rmaStatusMappings = new Dictionary<string, string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        rmaStatusMappings.Add("R", "Rejected");
        rmaStatusMappings.Add("A", "Approved");
        rmaStatusMappings.Add("P", "Pending");
        if (!IsPostBack)
        {
            var data = new DataClass[] {
                new DataClass() { RMAStatus = "P" }, 
                new DataClass() { RMAStatus = "A" }, 
                new DataClass() { RMAStatus = "R" }, 
                new DataClass() { RMAStatus = "P" }, 
            };
            gdv.DataSource = data;
            gdv.DataBind();
        }
    }
    protected void gdv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var rowStatus = ((DataClass)e.Row.DataItem).RMAStatus;
            // Set label to long status
            var lblStatus = e.Row.Cells[1].FindControl("lblStatus") as Label;
            if (lblStatus != null)
                lblStatus.Text = rmaStatusMappings[rowStatus];
            // Set drop down items
            var ddlStatus = e.Row.Cells[2].FindControl("ddlStatus") as DropDownList;
            if (ddlStatus != null)
            {
                ddlStatus.DataTextField = "Value";
                ddlStatus.DataValueField = "Key";
                ddlStatus.DataSource = rmaStatusMappings;
                ddlStatus.DataBind();
                ddlStatus.SelectedValue = rowStatus;
            }
        }
    }
