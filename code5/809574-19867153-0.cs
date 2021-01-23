    public void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack)
    	{
            LoadSubjects();
            LoadStatusCodes();
            chkUsers.Checked = true;
            chkAccount.Checked = false;
            CheckboxStatus();
    	}
    	
    	// here, every postback will execute
        // that's the reason you are getting every postback the called method
    }
    
    protected void chkUsers_OnCheckedChange(object sender, EventArgs e)
    {
    	CheckboxStatus();
    }
    
    protected void cboAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
    	CheckboxStatus();
    }
    
    protected void CheckboxStatus()
    {    	
        if (chkAccount.Checked)
        {
            cboActiveUsers.Enabled = false;
            ddlAuditor.Enabled = false;
            cboAccounts.Enabled = true;
            chkUsers.Checked = false;
        }
        // you could do it.. to toogle the enabled controls, instead on in checked
        /* 
        cboActiveUsers.Enabled = !chkAccount.Checked;
        ddlAuditor.Enabled = !chkAccount.Checked;
        cboAccounts.Enabled = chkAccount.Checked;
        chkUsers.Checked = chkAccount.Checked;
        */
        if (chkUsers.Checked == true)
        {
           cboActiveUsers.Enabled = true;
           ddlAuditor.Enabled = true;
           cboAccounts.Enabled = false;
           chkAccount.Checked = false;
        }    
        /*
        cboActiveUsers.Enabled = chkUsers.Checked;
        ddlAuditor.Enabled = chkUsers.Checked;
        cboAccounts.Enabled = !chkUsers.Checked;
        chkAccount.Checked = !chkUsers.Checked;*/
    }
