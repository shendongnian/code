    protected void lbnAddPOMeds_Click(object sender, EventArgs e)
    {
        TextBox txtReqPONum = (TextBox) Panel1.FindControl("txtReqPONum");
            int ReqPO = 0;
            if (txtReqPONum != null && int.TryParse(txtReqPONum.Text, out ReqPO) )
            {            
                int n = ReqPO;
                for (int i = 0; i < n; i++)
                {
                    UserControl myControl = (UserControl)Page.LoadControl("~/pomedsrow.ascx");//(UserControl)Page.LoadControl("Your control path/pomedsrow.ascx");
                    //Assigning the textbox ID name 
                    myControl.ID = "txtPOAmount" + "" + ViewState["num"] + i;
                    Panel1.Controls.Add(myControl);
                }
            }
    
    }
