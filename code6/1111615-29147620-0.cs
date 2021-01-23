    void button1_Click(object sender, EventArgs e)
    {
        //Get the strings (text)
        string textM = textBox1.Text;
        string textE = textBox2.Text;
        string textG = textBox3.Text;
        //Assuming you want unsigned numbers, convert to numeric types
        //You might want to put in exception handling for invalid inputs, watch for overflows etc.
        UInt16 bitsM = Convert.ToUInt16(textM);
        byte bitsE = Convert.ToByte(textE);
        UInt32 bitsG = Convert.ToUInt32(textG);
        /*
         * BitConverter puts the LSB at index 0, so depending on how you need to send the data,
         * you might want to reverse the bytes BitConverter.GetBytes(bitsM).Reverse();
         * or reverse the order you add them to the list
         */
        var byteList = new List<byte>();
        byteList.AddRange(BitConverter.GetBytes(bitsM));
        byteList.AddRange(BitConverter.GetBytes(bitsE));
        byteList.AddRange(BitConverter.GetBytes(bitsG));
        //Debugging message, uses LINQ 
        string bits = String.Join(" ", byteList.Select(b => b.ToString("X2")));
        MessageBox.Show(bits);
        
        //write the bytes
        var bitArray = byteList.ToArray();
        serialPort1.Write(bitArray, 0, 7);
    }
