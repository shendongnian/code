    public void InstantiateIn(Control container)
    {
        Literal l = new Literal();
        l.DataBinding += new EventHandler(this.BindData);
        container.Controls.Add(l);
    }
    // Create a public method that will handle the 
    // DataBinding event called in the InstantiateIn method. 
    public void BindData(object sender, EventArgs e)
    {
        Literal l = (Literal) sender;
        DataGridItem container = (DataGridItem) l.NamingContainer;
        l.Text = ((DataRowView) container.DataItem)[column].ToString();
    
    }
