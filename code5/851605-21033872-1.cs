    public void SharedMethod()
    {
        DialogResult dResult;
    
        dResult = MessageBox.Show("You have entered: " + textBox1.Text, "Message Box Info", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
    
        label1.Text = "You clicked " + dResult.ToString();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {   
        SharedMethod();
    }
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            SharedMethod();
        }
    }
