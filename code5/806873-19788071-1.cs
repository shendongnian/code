    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
      DateTime curDate = DateTime.Now;
      if (DateTime.TryParse(TextBox1.Text, out curDate))
      {
        Calendar1.SelectedDate = Convert.ToDateTime(TextBox1.Text);
      }
    }
