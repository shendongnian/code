    byte[] dBytes = StringToByteArray(hexString);
    
    //To get ASCII value of the hex string.
    string ASCIIresult = System.Text.Encoding.ASCII.GetString(dBytes);
    MessageBox.Show(ASCIIresult, "Showing value in ASCII");
    
    //To get the UTF8 value of the hex string
    string utf8result = System.Text.Encoding.UTF8.GetString(dBytes);
    MessageBox.Show(utf8result, "Showing value in UTF8");
      
