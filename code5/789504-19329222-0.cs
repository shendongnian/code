    protected void lbnAddPOMeds_Click(object sender, EventArgs e)
    {
        int ReqPO = Convert.ToInt32(txtReqPONum.Text);
        int n = ReqPO;
        for (int i = 0; i < n; i++)
        {
            pomedsrow myControl = new pomedsrow();
            //Assigning the textbox ID name 
            myControl .ID = "txtPOAmount" + "" + ViewState["num"] + i;
            this.Form.Controls.Add(myControl );
        }
    
    }
