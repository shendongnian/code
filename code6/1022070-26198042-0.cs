    private void comboBox2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            var price = dt.Select("desc = '" + comboBox2.Text + "'", "price ASC");
            textBox9.Text = price[0][2].ToString();
        }
        catch(Exception xyz)
        {}
    }
