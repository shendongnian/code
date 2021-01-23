    static DateTime RequestStartDate()
    {
        while (true)
        {
            try
            {
                // Ask for date and parse it
                // ...
                return parsedDate;
            }
            catch (Exception e) // See below...
            {
                MessageBox.Show("The date entered is not valid");
            }
        }
    }
