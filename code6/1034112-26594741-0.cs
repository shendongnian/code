    int Count = 0;    
    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        for (int i = 0; i < dataGrid1.Items.Count; i++)
      {
        string cellContent = dtReferral.Rows[i][0].ToString();
        try
        {
            if (cellContent != null && cellContent.Substring(0, textBox1.Text.Length).Equals(textBox1.Text))
            {
                Count++;
                object item = dataGrid1.Items[i];
                dataGrid1.SelectedItem = item;
                dataGrid1.ScrollIntoView(item);
                //row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                break;
            }
        }
        catch { }
    }
