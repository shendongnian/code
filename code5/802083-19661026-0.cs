        DateTime dateEntered;
        string input = "1444";
        if (DateTime.TryParseExact(input, "HH:mm", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out dateEntered))
        {
            MessageBox.Show(dateEntered.ToString());
        }
        else
        {
            MessageBox.Show("You need to enter valid 24hr time");
        }
