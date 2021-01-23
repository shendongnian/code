    protected void Page_Load(object sender, EventArgs e)
    {
    xx.Visible=false;
    if (IsPostBack)
        return;
    }
    
    protected void CheckBoxList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
    if (CheckBoxList1.SelectedValue == "1") 
    {
        xx.Visible=true;
    }
    }
