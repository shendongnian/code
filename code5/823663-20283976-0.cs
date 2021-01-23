    DataTable table;
    Image blueStar = new Image();
    protected void Page_Load(object sender, EventArgs e)
    {
       blueStar = ImageBlueStar;
       table= new DataTable();
       table.Columns.Add("Title Text");
       tabela.Rows.Add("URL FROM IMAGE", "SOME TEXT");
       SPGridView novaGrid = new SPGridView();
       novaGrid.DataSource = table.DefaultView;
       novaGrid.AutoGenerateColumns = false;
       novaGrid.Columns.Add(new ImageField { DataImageUrlField = "Title Text"});
            
       Controls.Add(novaGrid);
       novaGrid.DataBind();
    }
