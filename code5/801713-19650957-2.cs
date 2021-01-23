    string text = maskedTextBox1.Text;
    string[] parts = text.Split(':');
    if (parts.Length == 2)
    {
        bool successHour, successMinute;
        int hour, minute;
        successHour = int.TryParse(parts[0], out hour);
        successMinute = int.TryParse(parts[1], out minute);
        if (successHour == true && successMinute == true)
        {
            MessageBox.Show("Hour=" + hour + " minute=" + minute);
        }
        else
        {
            MessageBox.Show("Invalid input");
        }
    }
    else
    {
        MessageBox.Show("Invalid input");
    }
