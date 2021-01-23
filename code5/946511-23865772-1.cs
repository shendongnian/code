    void cmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	if(e.AddedItems[0].ToString() == "item3")
    	{
    		var txt = new TextBox();
    		var row = (int)((ComboBox)sender).Tag;
    		Grid.SetRow(txt, i);
            Grid.SetColumn(txt, 1);
            grid2.Children.Add(txt);
    	}
    }
