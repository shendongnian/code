    private void MyForm_Closing(object sender, CancelEventArgs e)
    {
        if(MessageBox.Show("Are you sure want to exit the App?", "Test", MessageBoxButtons.YesNo) == DialogResult.No)
        {
          e.Cancel = true;
        }
    }
