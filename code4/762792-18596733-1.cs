    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    try
    {
    switch (MessageBox.Show("Do you want to exit ?", "Form1", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
    {
    case DialogResult.Yes:
    this.Close();
    break;
    
    case DialogResult.No:
    e.Cancel = true;
    break;
    }
    }
    catch (Exception)
    {
    //Exception handling code goes here.
    }
    }
