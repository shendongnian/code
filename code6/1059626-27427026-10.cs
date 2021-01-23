    private void Submit_Button_Click(object sender, RoutedEventArgs e)
    {
        Dictionary<string, string> tagDict = new Dictionary<string, string>();
        foreach(Control ctrl in MainGrid.Children)
        {      
            TextBox tb = ctrl as TextBox;
            if (tb != null) 
            {
                 if (fDic[(string)text.Tag] != text.Text)
                 {
                     string tagString = tb.Tag.ToString();
                     string textString = tb.Text;
                     tagDict.Add(tagString, textString);
                 }
            }
        }
    }
