    private void btnResult_Click(object sender, EventArgs e)
    {
        int a = 0;
        int b = 0;
        if (!int.TryParse(first, out a))
        {
            MessageBox.Show("first is not a number");
            return;
        }
        if (!int.TryParse(second, out b))
        {
            MessageBox.Show("second is not a number");
            return;
        }
        int c = a + b;
        txtResult.Text = c.ToString();
    }
