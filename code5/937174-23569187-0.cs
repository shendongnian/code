    int i=0;
    double itemHeight = 30;
    if (p.Component.Type == "Combo")
    {
        var cb = new ComboBox();
        foreach (var item in p.Component.Attributes.Items)
        {
            cb.Items.Add(item);  //These item contains a l0,15,45,60 to select through combo box
        }
        Canvas.SetTop(cb, itemHeight * i++);
        result.Add(cb);                    
    } 
    var txtblk = new TextBlock();
    txtblk.Text = "Max Amount";
    Canvas.SetTop(txtblk, itemHeight * i++);
    result.Add(txtblk);
