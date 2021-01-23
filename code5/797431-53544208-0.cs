    private void salary_texbox_PreviewTextInput(object sender, TextCompositionEventArgs e){
      Regex regex = new Regex ( "[^0-9]+" );
      string text;
      if (textBox.CaretIndex==textBox.Text.Length) {
        text = textBox.Text + e.Text;
      } else {
        text = textBox.Text.Substring(0, textBox.CaretIndex)  + e.Text + textBox.Text.Substring(textBox.CaretIndex);
      }
      if(regex.IsMatch(text)){
          MessageBox.Show("Error");
      }
    }
