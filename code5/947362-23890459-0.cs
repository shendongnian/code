    var inputStr = "0x255044462D312E330D0A312030206F626A0D0";
    var hex = inputStr.Substring(2);
    
    int NumberChars = hex.Length / 2;
    byte[] pdfFile = new byte[NumberChars];
    using (var sr = new StringReader(hex))
    {
    	for (int i = 0; i < NumberChars; i++)
    		pdfFile[i] = Convert.ToByte(new string(new char[2]{(char)sr.Read(), (char)sr.Read()}), 16);
    }
