    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;  // cancel the request to close
            this.Hide();      // hide the form instead
        }
    }
    
