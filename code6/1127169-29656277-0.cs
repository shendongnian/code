    private void button1_Click(object sender, EventArgs e)     
    {
      try
      {
        if (!serialPort1.IsOpen)
        {    
          serialPort1.Open();
          this.button1.Text = "Close Port";                   
        }
        else
        {
          serialPort1.Close();
          this.button1.Text = "Open Port";  
        }   
      }
      catch (UnauthorizedAccessException ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
