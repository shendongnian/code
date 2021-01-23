    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = Request.Form["__EVENTTARGET"];
        int index1 = int.Parse(result.Substring(result.IndexOf("$") + 1));
        if (index1 == 0)
        {
            bool tf = CheckBoxList1.Items[index1].Selected ? true : false;
            CheckAll(tf);
        }
    }
    void CheckAll(bool tf)
    {
        foreach (ListItem item in CheckBoxList1.Items)
        {
            item.Selected = tf;
        }
    }
