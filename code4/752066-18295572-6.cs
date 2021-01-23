     protected void Page_Load(object sender, EventArgs e)
        {
            DetailsView dv = new DetailsView();
            dv.ID = "MyDv";
            dv.DataSource = GetDataSet(); // returns a dataset filled using Select Query
    
            TemplateField tf = new TemplateField();
            tf.ItemTemplate = new AddTemplateToDetailsView(ListItemType.Item);
    
            dv.Fields.Add(tf);
            
            dv.DataBind();
            placeholder1.Controls.Add(dv);
            
        }
