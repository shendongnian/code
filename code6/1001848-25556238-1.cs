    private void button1_Click(object sender, EventArgs e)
    {
        var bytes = new byte[] { 0x1b, 0x01, 0x09 };
        port.Write(bytes, 0, bytes.Length);
        port.Flush(); // make sure everything is written
    }
