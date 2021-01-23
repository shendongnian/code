    private const _maxCharacters = 8;
    private code = "";
    private BlockingCollection<string> codes = new BlockingCollection<string>();
    private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        if (addtag == false)
        {
            data = serialPort.ReadExisting(); // read what came from the RFID reader
            while (data.Length > 0)
            {
                string fragment =
                    data.Substring(0, Math.Min(maxCharacters - code.Length, data.Length));
                code += fragment;
                data = data.Substring(fragment.Length);
                if (code.Length == maxCharacters)
                {
                    codes.Add(code);
                    code = "";
                }
            }
        }
        else
        {  
        }
    }
