    private void GenateGridView()
    {
        TemplateField tempField;
        DynamicTemplate dynTempItem;
        Label label;
    
        GridView gvDynamicArticle = new GridView();
    
        gvDynamicArticle.Width = Unit.Pixel(500);
        gvDynamicArticle.BorderWidth = Unit.Pixel(0);
        gvDynamicArticle.Caption = "<div>Default Grid</div>";
        gvDynamicArticle.AutoGenerateColumns = false;
        gvDynamicArticle.RowDataBound += new GridViewRowEventHandler(gvDynamicArticle_RowDataBound);
        DataTable data = getBindingData();
    
        for (int i = 0; i < data.Columns.Count; i++)
        {
            tempField = new TemplateField();
            dynTempItem = new DynamicTemplate(ListItemType.AlternatingItem);
    
            string ColumnValue = data.Columns[i].ColumnName;
            tempField.HeaderText = ColumnValue;
    
            label = new Label();
    
            label.ID = string.Format("Label{0}", i);
            dynTempItem.AddControl(label, "Text", ColumnValue);
            label.Width = 100;
    
            tempField.ItemTemplate = dynTempItem;
            gvDynamicArticle.Columns.Add(tempField);
        }
    
        gvDynamicArticle.DataSource = data;
        gvDynamicArticle.DataBind();
    
        divContainer.Controls.Add(gvDynamicArticle);
    }
