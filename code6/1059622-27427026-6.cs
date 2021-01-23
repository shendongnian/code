    private void Submit_Button_Click(object sender, RoutedEventArgs e)
    {
        foreach(Control ctrl in MainGrid.Children)
        {
            TextBox tb = ctrl as TextBox;
            if (tb != null) 
            {
                 if (fDic[(string)text.Tag] != text.Text)
                 {
                     //do your thing here
                 }
            }
        }
    }
