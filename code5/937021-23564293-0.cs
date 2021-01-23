    protected void AddItem(object o, string t, string v, int i)
    {
        if(o is DropDownList) {
            ((DropDownList) o).Items.Insert(i, new ListItem(t, v));
        }
    }
