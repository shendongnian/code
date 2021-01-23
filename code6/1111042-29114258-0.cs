    <select id="ddlDOBDay" runat="server" />
    <select id="ddlDOBMonth" runat="server" />
    <select id="ddlDOBYear" runat="server" />
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
            {
                // Add items like below example
                ddlDOBDay.Items.Add(new ListItem("1", "1"));
                .
                .
                ddlDOBDay.Items.Add(new ListItem("31", "31"));
                ddlDOBMonth.Items.Add(new ListItem("January", "1"));
                .
                .
                ddlDOBDay.Items.Add(new ListItem("December", "12"));
                ddlDOBYear.Items.Add(new ListItem("1990", "1990"));
                .
                .
                ddlDOBYear.Items.Add(new ListItem("2015", "2015"));
            }
    }
