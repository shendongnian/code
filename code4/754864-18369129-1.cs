    private void btnResult_Click(object sender, EventArgs e)
    {
        int a, b;
        if (int.TryParse(first, out a) && int.TryParse(second, out b))
        {
            int c = a + b;
            txtResult.Text = c.ToString();
        } 
        else
        {
            MessageBox.Show("Invalid Input!");
        }
    }
