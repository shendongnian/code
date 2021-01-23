        private string radioContent = "";
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = (sender as RadioButton);
            radioContent = radio.Content.ToString();
        }
    and on the save button click,
      private void save_data(object sender, RoutedEventArgs e)
      {
       window2 win2 = new window2();
    
       MessageBox.Show(radioContent);// here when it displays " System.Windows.Controls.StackPanel "
      if (radioContent.Length <= 0)
        MessageBox.Show("Please select a type.");
      else
        win2.name.Text = radioContent.ToString();
      win2.Show();
      //this.Close();
       }
