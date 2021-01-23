    //declare a DataGridViewCellStyle
    DataGridViewCellStyle style = new DataGridViewCellStyle();
    //set it's BackColor to green
    style.BackColor = Color.Green;
    var button = new DataGridViewButtonColumn
        {
            FlatStyle = FlatStyle.Popup,
            //assign the style property to DefaultCellStyle
            DefaultCellStyle = style,
            Width = 50
        };
