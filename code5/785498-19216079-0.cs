        private void textBox1_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(textBox1.Text, out value))
                textBox1.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            else
                textBox1.Text = String.Empty;
        }
