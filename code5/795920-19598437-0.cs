    { 
    mySerialPort.Open();
            byte[] bytesToSend = StringToByteArray("A00265F9");// correct command to reset READER
            mySerialPort.Write(bytesToSend, 0, 4);
    }
    public static byte[] StringToByteArray(string hex)
            {
                return Enumerable.Range(0, hex.Length)
                                 .Where(x => x % 2 == 0)
                                 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                                 .ToArray();
            }
