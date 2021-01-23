    //
    // Time-out after 1 minute after receiving last message
    //
    stream.ReadTimeOut = 60 * 1000;
    BinaryFormatter deserializer = new BinaryFormatter();
    try
    {
        while (!interrupted)
        {
            System.Diagnostics.Debug.WriteLine("Waiting for the message...");
            AbstractMessage msg = (AbstractMessage)deserializer.Deserialize(stream);
            System.Diagnostics.Debug.WriteLine("Message arrived: " + msg.GetType());
            //
            // Exit while-loop when receiving a "Connection ends"  message.
            // Adapt this if condition to whatever is appropriate for
            // your AbstractMessage type.
            //
            if (msg == ConnectionEndsMessage) break;
            raiseEvent(msg);
        }
    }
    catch (IOException ex)
    {
        ... handle timeout and other IOExceptions here...
    }
