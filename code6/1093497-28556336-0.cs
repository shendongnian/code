    private void update()
    {
      int count = 0;
      foreach(TextBox tbx in container.Controlers)
      {
         if(!String.IsNullOrEmpty(tbx.Text))
         count++;
      }
    
      CountertextBox.Text = count.ToString();
    }
