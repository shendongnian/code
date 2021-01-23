      if (Regex.IsMatch(textbox3.Text, @"^\d{10}$")) {
        textbox4.Text = textbox1.Text + Environment.NewLine + textbox2.Text + Environment.NewLine + textbox3.Text; 
      }
      else {
        textbox3.Text = string.Empty;
        textbox4.Text = string.Empty;
        MessageBox.Show("Please, enter a 10 digit Contact No.", "Error");
      }
