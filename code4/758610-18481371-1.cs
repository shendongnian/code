    string array="$MT!BOOTLOADER";  
    byte[] hexdecimal={0x01,0x05,0x36};
    byte[] bytesOrig = Encoding.ASCII.GetBytes(array);
    byte[] bytesFinal = bytesOrig;
    Array.Resize(ref bytesFinal, bytesFinal.Length + hexdecimal.Length);
    Array.Copy(hexdecimal, 0, bytesFinal, bytesOrig.Length, hexdecimal.Length);
	
    // bytesFinal contains all the bytes
