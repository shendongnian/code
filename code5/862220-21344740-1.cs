    DataWriter writer = new DataWriter();
    writer.WriteString("Test");
    proximityDevice.PublishBinaryMessage("Windows:WriteTag.Tietgen", writer.DetachBuffer(), new MessageTransmittedHandler((pDevice, id) =>
    {
        Debug.WriteLine("Message sent.");
    }));
