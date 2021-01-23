        protected void dcDdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recPartDdl.SelectedItem.Text != "All")
            {
                DropDownList ddl = (DropDownList)sender;
                //First check type of ddl.SelectedValue and then process
                string value = ddl.SelectedValue;
                foreach(GridViewRow row in allRmaGv.Rows)
                {
                    DropDownList dcDropDown = (DropDownList)row.FindControl("dcDdl");
                    dcDropDown.SelectedValue = value;
                }
            }
        }
