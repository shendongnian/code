    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dataTbl = this.GetData();
        // Enumerate over the DataRows and 
        // Group them by 'Author'
        // Select a new anonymous type where
        // we can reference the
        //  key => Author
        //  group => Books
        IEnumerable<dynamic> data = dataTbl.Rows.Cast<DataRow>()
            .GroupBy<DataRow, String>(d => Convert.ToString(d["Author"]))
            .Select<IGrouping<String, DataRow>, dynamic>(grp => {
                return new {
                    Author = grp.Key,
                    Books = grp
                };
            });
    
        RepeaterOuter.DataSource = data;
        RepeaterOuter.DataBind();
    }
