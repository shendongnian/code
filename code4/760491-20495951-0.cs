    PageLoad()
    {
    BindGridview();
    }
    Public void BindGridview()
    {
    //Binding codes and add extra column codes
    for (int i = 0; i < models.Length && i < 3; i++)
                {
                    var model = models[i];
    
                    //Add gridview rows
                    BoundField bf = new BoundField();
                    bf.DataField = "Attribute" + i;
                    bf.HeaderText = model.AttributeName;
                    bf.Visible = true;
    
                    gvFiles.Columns.Insert(6 + i, bf);
    
                }
    }
