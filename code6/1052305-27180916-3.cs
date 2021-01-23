    //declare a DataGridViewCellStyle
    DataGridViewCellStyle style = new DataGridViewCellStyle();
    //backcolor when the button is not selected
    style.BackColor = Color.Green;
    //backcolor when the button is selected
    style.SelectionBackColor = Color.Yellow;
    var button = new DataGridViewButtonColumn
        {
            FlatStyle = FlatStyle.Popup,
            //assign the style property to DefaultCellStyle of DataGridViewButtonColumn
            DefaultCellStyle = style,
            Width = 50
        };
    
    //finally, add the button column to your DataGridView control
    dgModuleView.Columns.Add(button);
