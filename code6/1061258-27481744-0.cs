    string path = ""; // Your file path.
    byte[] data = File.ReadAllBytes(path);
    
    // Initialize the port using a name, a baud rate value and a parity value.
    using (var port = new SerialPort("COM1", 4800, Parity.None))     
    {
        port.Open();
        port.Write(data, 0, data.Length);
    }
