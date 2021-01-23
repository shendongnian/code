    private string hexConverter(string hexString)
    {
        string asciiCharString ="" ;
    
        var splitResult = hexString.Split('-');
    
        foreach (string hexChar in splitResult )
        {
            var byteChar = int.Parse(hexChar, NumberStyles.HexNumber);
            asciiCharString += (char)byteChar;
        }
    
        return asciiCharString;
    }
    // Test
    private void button1_Click(object sender, EventArgs e)
    {
        string hexString = "48-65-6C-6C-6F-20-77-6F-72-6C-64-21-21-21";
        string asciiString = hexConverter(hexString);
    
        MessageBox.Show(asciiString);
    }
    
