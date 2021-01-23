    private void textBox1_Validated(Object sender, EventArgs e)
    {
        Double dbl;
        if (!String.IsNullOrWhiteSpace(textBox1.Text) && 
            Double.TryParse(textBox1.Text, out dbl))
        {
            //Replace with your formatting of choice...
            textBox1.Text = String.Format("{0:F3}", dbl);
        }
    }
