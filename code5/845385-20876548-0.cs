    protected void Page_Load(object sender, EventArgs e)
    {
                Table t = new Table();
                TableRow row = new TableRow();              
                for (int i = 0; i < 3 ; i++)
                {
                    GridView g=new GridView();
                    g.DataSource = SqlDataSource1; //Fill GridView
                    g.DataBind(); // Bind Gridview
                    TableCell cell = new TableCell();
                    cell.Controls.Add(g);
                    row.Controls.Add(cell);                   
                }
                t.Controls.Add(row);
                PlaceHolder1.Controls.Add(t);
    }
