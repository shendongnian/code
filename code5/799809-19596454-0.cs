     if (File.Exists(TextBox.Text.Trim()))
      {
        File.Copy(TextBox.Text, "C:/");
      }
    else
      {
        MessageBox.Show("Please drag a file to the Tex Box!");
        return;
      }
