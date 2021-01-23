    private void btn_addnew_Click(object sender, RoutedEventArgs e)
    {
        //1st Column TextBox
        txt1 = new TextBox();
        Grid.SetRow(txt1, i);
        SetGridRow(text1, i);
        ...
        grid1.Children.Add(txt1);
        count++;
    }
