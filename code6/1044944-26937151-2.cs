    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (lbOuter.SelectedIndex < (lbOuter.Items.Count - 1))
        {
            lbOuter.SelectedIndex++;
        }
        else
        {
            lbOuter.SelectedIndex = 0;
        }
    }
    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        if (lbInner.SelectedIndex < (lbInner.Items.Count - 1))
        {
            lbInner.SelectedIndex++;
        }
        else
        {
            lbInner.SelectedIndex = 0;
        }
    }
