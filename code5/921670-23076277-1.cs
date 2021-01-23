    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CheckBox cbx = e.Item.FindControl("myCbx") as CheckBox;
            if (cbx != null)
            {
                cbx.Attributes.Add("onclick", "function();");
            }
        }
