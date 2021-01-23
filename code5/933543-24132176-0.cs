    `private void OpenButton_Click(object sender, EventArgs e)
    {
       try
       {
          if (sp.IsOpen == false)
          {
             sp.Open();                    
          }
          else
          {
             MessageBox.Show("port 7 is already opened");
          }
       }
       catch (UnauthorizedAccessException ex)
       {
          MessageBox.Show(ex.Message);
       }
    }`
