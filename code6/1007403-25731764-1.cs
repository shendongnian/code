    using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(ofd.FileName)))
    {
         bw.Seek(Convert.ToInt32(toolStripTextBox1.Text, 16), SeekOrigin.Begin);
         bw.Write((byte)textBox1.Text);
    }
