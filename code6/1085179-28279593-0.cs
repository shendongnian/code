    protected void Button1_Click(object sender, EventArgs e)
    {
        ArrayList aList = (ArrayList)this.Session["someParameter"];
        if (aList == null)
        {
             this.Session["someParameter"] = aList = new ArrayList();
        }
        aList.Add(DropDownList1.SelectedValue);
        ListBox1.DataSource = aList;
        ListBox1.DataBind();
    }
