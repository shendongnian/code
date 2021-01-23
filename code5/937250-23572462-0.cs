    textBox2.Text=orderNo.ToString();
    textBox2.Visible=False;
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        textBox11.Text = Convert.ToString(orderNo);
    }
