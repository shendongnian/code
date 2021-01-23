    public IssueReport(DataTable issuesTable)
    {
	    InitializeComponent();
    	this.DataSource = issuesTable;
    	xrlabelIssueNumber.DataBindings.Add("Text", this.DataSource, "IssueID");
    	xrlabelAssignedUser.DataBindings.Add("Text", this.DataSource, "Assigned User");
    	xrlabelPriority.DataBindings.Add("Text", this.DataSource, "Priority");
    	xrlabelCategory.DataBindings.Add("Text", this.DataSource, "IssueCategory");
    	xrlabelReceivedDate.DataBindings.Add("Text", this.DataSource, "ReceivedDate");
    	xrlabelDueDate.DataBindings.Add("Text", this.DataSource, "DueDate");
    	xrlabelProduct.DataBindings.Add("Text", this.DataSource, "Product");
    	xrlabelStatus.DataBindings.Add("Text", this.DataSource, "Status");
    	xrlabelSubStatus.DataBindings.Add("Text", this.DataSource, "Sub-Status");
    	xrlabelVersion.DataBindings.Add("Text", this.DataSource, "VersionNumber");
    	xrlabelCustomer.DataBindings.Add("Text", this.DataSource, "CustomerName");
    	xrlabelLocation.DataBindings.Add("Text", this.DataSource, "LocationName");
    	xrlabelRoom.DataBindings.Add("Text", this.DataSource, "RoomName");
    	xrlabelPOC.DataBindings.Add("Text", this.DataSource, "POC");
    	xrlabelOfficeNumber.DataBindings.Add("Text", this.DataSource, "OfficePhone");
    	xrlabelCallbackNumber.DataBindings.Add("Text", this.DataSource, "CallbackNumber");
    	xrlabelEmail.DataBindings.Add("Text", this.DataSource, "Email");
    	xrlabelAlternateEmail.DataBindings.Add("Text", this.DataSource, "AlternateEmail");
    	xrlabelSummary.DataBindings.Add("Text", this.DataSource, "IssueSummary");
