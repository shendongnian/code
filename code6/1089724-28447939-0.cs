    // Simple holder for header and data
    class Message
    {
        public int Field1 { get; private set; }
        public short Length { get; private set; }
        public int Field2 { get; private set; }
        public short Index { get; private set; }
        public byte[] Data { get; private set; }
        public Message(int field1, short length, int field2, int index, byte[] data)
        {
            Field1 = field1;
            Length = length;
            Field2 = field2;
            Index = index;
            Data = data;
        }
    }
    private void btnC_Click(object sender, EventArgs e)
    {
        sck.Connect(endPoint);
        // If Connect() completes without an exception, you're connected
        Form1.ActiveForm.Text = Form1.ActiveForm.Text + " - Connected";
        using (NetworkStream stream = new NetworkStream(sck))
        using (BinaryReader reader = new BinaryReader(stream))
        {
            Message message;
            while ((message = await Task.Run(() => ReadMessage(reader))) != null)
            {
                // process message here, preferably asynchronously
            }
        }
    }
    private Message ReadMessage(BinaryReader reader)
    {
        try
        {
            int field1, field2;
            short length, index;
            byte[] data;
            field1 = reader.ReadInt32();
            length = reader.ReadInt16();
            field2 = reader.ReadInt32();
            index = reader.ReadInt16();
            // NOTE: this is the simplest implementation based on the vague
            // description in the question. I assume "length" contains the
            // actual length of the _remaining_ data, but it could be that
            // the number of bytes to read here needs to take into account
            // the number of bytes already read (e.g. maybe this should be
            // "length - 20"). You also might want to create subclasses of
            // Message that are specific to the actual message, and use
            // the BinaryReader to initialize those based on the data read
            // so far and the remaining data.
            data = reader.ReadBytes(length);
        }
        catch (EndOfStreamException)
        {
            return null;
        }
    }
