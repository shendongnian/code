    private void textBox1_TextChanged(object sender, EventArgs e)
    {
      if (textBox1.Text == String.Empty) {
        textBox2.Text = " ";
      } else {
        if (double.TryParse(textBox1.Text, out Diameter1)) {
          Area1 = Math.PI * Math.Pow((Diameter1 / 2), 2);
          textBox2.Text = Area1.ToString();
        } else {
          textBox2.Text = "-not numeric-";
        }
      }
    }
