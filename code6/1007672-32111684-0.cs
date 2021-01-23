    protected void btnEdit_Click(object sender, EventArgs e)
        {
            dc.Company_code = Convert.ToInt32(Session["company_code"].ToString());
            Button btn = (Button)sender;
            GridViewRow gv = (GridViewRow)btn.NamingContainer;
            string repair_id = gv.Cells[0].Text;
            ViewState["repair_id"] = repair_id;
            ddlMachine.SelectedIndex=ddlMachine.Items.IndexOf(ddlMachine.Items.FindByText(gv.Cells[1].Text));            
        }
