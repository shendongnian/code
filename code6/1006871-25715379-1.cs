    public void CaesarCipherOptimal(string input, int shift)
    {
        var res = "";
        byte[] asciiInput = Encoding.ASCII.GetBytes(input);
        // Loop for every character in the string, set the value to the element variable
        foreach (byte element in asciiInput)
        {
            if (element >= 65 && element <= 90)
            {
                var indx = (element + shift - 65) % 26 + 65;
                res += (char)indx;
            }
        }
        return res;
    }
