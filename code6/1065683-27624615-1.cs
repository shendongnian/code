    // The program will attempt to send a message
    try
    {
        MySever.Send(MyMsg);
        MessageBox.Show("Message sent successfully");
    }
    catch (Exception ex)
    {
        // Whoops there was an error sending the message, better tell the user what happened.
        MessageBox.Show(String.Format("Message Failed To send because: {0}", ex.message);
    }
