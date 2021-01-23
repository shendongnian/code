    string str = "0111001101101000";
    byte[] bytes = new byte[str.Length / 8];
    for (int ix = 0, weight = 128, ix2 = 0; ix < str.Length; ix++) {
        if (str[ix] == '1') {
            bytes[ix2] += (byte)weight;
        }
        weight /= 2;
        // Every 8 bits we "reset" the weight 
        // and increment the ix2
        if (weight == 0) {
            ix2++;
            weight = 128;
        }
    }
    string output = Encoding.ASCII.GetString(bytes); //encoding    
