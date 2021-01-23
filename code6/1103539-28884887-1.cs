      int sum=0;
      private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
      {
         sum = sum + Convert.ToInt32(_1.Text);
         Add.Text = sum.ToString();
      }
      private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
      {
          sum = sum + Convert.ToInt32(_2.Text);
          Add.Text = sum.ToString();
      }
