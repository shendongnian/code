    foreach (Telerik.Web.UI.RadListViewItem item in lvAllUsers.Items)
    {
        if (((System.Web.UI.WebControls.CheckBoxList)(((System.Web.UI.Control)(item)).Controls[1])).Items[0].Selected)
        {
            ccUserNames.Add(((System.Web.UI.WebControls.Label)(((System.Web.UI.Control)(item)).Controls[7])).Text);
        }
    }
