    static BindingList<xml.Table> table;
    public BindingList<xml.Table> FetchTable()
    {
    if(table == null)
    {
     table = new BindingList<xml.Table>();
    }
    return table
    }
    dataGridView4.DataSource = FetchTable();
