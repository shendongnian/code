    int dayOfWeek;
    if (!int.TryParse(textBox1.Text, out dayOfWeek))
    {
        // you can remove the MessageBox if you're not interested in feedback 
        MessageBox.Show("Value entered is not a valid day number!");
        return;
    }
    String dayName = null;
    switch (dayOfWeek)
    {
        //...
