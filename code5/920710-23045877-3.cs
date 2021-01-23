    private void ComboBox_SelectionChanged(object sender,
                                           SelectionChangedEventArgs e)
    {
       if (((ComboBoxItem)combo1.SelectedItem).Content.ToString() == "Car Model")
       {
          combo2.Items.Clear();
          combo2.Items.Add("BMW");
          combo2.Items.Add("Mercedes");
       }
       else
       {
          combo2.Items.Clear();
          combo2.Items.Add("4 Wheels");
          combo2.Items.Add("5 Wheels");
       }
    }
