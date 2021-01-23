    private void MesssageTransmitted(ProximityDevice sender, long messageId)
    {
        Debug.WriteLine("Message sent!");
        ProximityDevice.GetDefault().StopPublishingMessage(messageId);
    }
