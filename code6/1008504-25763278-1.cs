    var seekPos = int.Parse(toolStripTextBox1.Text, NumberStyles.HexNumber);
    var data = UInt32.Parse(textBox1.Text, NumberStyles.HexNumber);
    using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(ofd.FileName)))
    {
         bw.Seek(seekPos, SeekOrigin.Begin);
         bw.Write(data); //data is UInt32, correct overload is chosen
    }   
