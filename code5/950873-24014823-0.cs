    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = subject.Text;
        string m = message.Text;
        // Grab the current list from the session and add the 
        // currently selected DropDown item to it.
        List<mEvent> authors = (List<mEvent>)Session[authorKey];
        authors.Add(new mEvent(s,m));
        Session[authorKey] = authors;
        BindList();
    }
