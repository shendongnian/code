     private void CalcTextBox_TextChanged(object sender, RoutedEventArgs e)
     {
         int testInt = 0;
         if (((TextBox)sender).Text.Length > 8 && int.TryParse(((TextBox)sender).Text, testInt))
         {
            ((TextBox)sender).Text = String.Format("{0:E2}", testInt); 
         }
     }
