    private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtGuid.Text.Contains("//"))
            {
                txtGuid.ForeColor = Color.Red;
            }
        }
