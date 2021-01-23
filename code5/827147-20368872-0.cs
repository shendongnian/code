    protected void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataListItem item in DataList1.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("checkbox");
                LinkButton lnkbtnActivate = (LinkButton)item.FindControl("lnkpro");
                if (chk.Checked == true)
                {
                    string Result = lnkbtnActivate.Text;
                }
            }
        }
