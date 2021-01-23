    string ticketId = null;
    InternetMessageHeader ticketHeader =
        message.InternetMessageHeaders.Find("ticket-id");
    if (ticketHeader != null)
        ticketId = ticketHeader.Value;
    if (!string.IsNullOrEmpty(ticketId)) {
        // TODO: Do something with the ticket ID
    }
