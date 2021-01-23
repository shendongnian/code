    private void FetchData()
    {
        ddlCardType.SelectedIndex = ddlCardType.Items.IndexOf(ddlCardType.Items.FindByValue("2"));
        ddlProductType.SelectedIndex = ddlProductType.Items.IndexOf(ddlProductType.Items.FindByValue("5"));
    }
    
    private void FetchData_Q2()
    {
        ddlCardType.SelectedIndex = ddlCardType.Items.IndexOf(ddlCardType.Items.FindByValue("1"));
        ddlProductType.SelectedIndex = ddlProductType.Items.IndexOf(ddlProductType.Items.FindByValue("1"));
    }
