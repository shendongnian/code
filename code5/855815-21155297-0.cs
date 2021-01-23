    DateTime creationDate;
    if (DateTime.TryParseExact(CreationDateTextBox.Text, "MM-dd-yyyy",
                               CultureInfo.InvariantCulture, DateTimeStyles.None,
                               out creationDate))
    {
        // Use creationDate within a database command, but *don't* convert it
        // back to a string.
    }
    else
    {
        // Handle invalid input
    }
