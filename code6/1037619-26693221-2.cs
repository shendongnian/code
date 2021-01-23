    private void button1_Click(object sender, EventArgs e)
    {
        DateTime dt;
        string choosefridaydate = textBox1.Text;
        if (DateTime.TryParse(choosefridaydate, out dt))
        {
            monthCalendar1.SetDate(dt);
        }
    }
