    protected void AddItem(DropDownList dropDown, string t, string v, int i) {
        dropDown.Items.Insert(i, new ListItem(t, v));
    }
    protected void AddItem(Label l, string t, string v, int i) { 
        l.Text = t + v + i;
    }
    AddItem(ddlSubject, "- Please select message subject -", "No subject given", 0);
    AddItem(lblSubject, "Hello", "World", 15);
