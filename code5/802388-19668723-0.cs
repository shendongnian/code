    protected void btnView_Click(object sender, EventArgs e)
            {
                foreach (ListItem li in lbxCheckDates.Items)
                {
                    if (li.Selected == true)
                    {
                        lblMessage.Text = "";
                        string checkDate = lbxCheckDates.SelectedItem.Text;
                        Session.Add("CheckDates", checkDate);
                        Page.ClientScript.RegisterStartupScript(
                        this.GetType(), "OpenWindow", "window.open('Paystub.aspx','_newtab');", true);
                    }
                }
            }
