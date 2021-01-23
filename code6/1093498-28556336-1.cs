    private void update()
    {
      int count = 0;
      foreach(TextBox tbx in container.Controls)
      {
         if(!String.IsNullOrEmpty(tbx.Text))
         count++;
      }
    
      CountertextBox.Text = count.ToString();
    }
