    private void button1_Click(object sender, EventArgs e)
            {
    #region "New"
                //byte[] bytes = new byte[str.Length * sizeof(char)];
                //System.Buffer.BlockCopy(textBox1.Text.ToCharArray(), 0, bytes, 0, bytes.Length);
                //using (FileStream fs = File.OpenWrite(listBox1.SelectedItem.ToString()))
                //{
                //    fs.Seek(0x83C410, SeekOrigin.Begin);
                //    fs.Write(bytes, 0, 7);
                //}
    #endregion
     
                BinaryWriter wr = new BinaryWriter(File.OpenWrite(listBox1.SelectedItem.ToString()));
                textBox8.Text = ConvertToHex(Encoding.UTF8.GetBytes(textBox8.Text));
                for (int i = 0x83C410; i <= 0x83C417; i++)
                {
     
                   // wr.Write(textBox1.Text);
                }
                wr.Close();
            }
