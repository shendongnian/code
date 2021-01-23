      private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
      {
         if (!Regex.IsMatch(TextBox1.Text, @"^\d{1,14}(?:\.\d{0,2}){0,1}$"))
         {
            TextBox1.Text = TextBox1.Text.Substring(0, TextBox1.Text.Length - e.Changes.Last().AddedLength);
            TextBox1.CaretIndex = TextBox1.Text.Length;
         }
      }
