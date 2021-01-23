    private void button1_Click(object sender, EventArgs e)
            {
                BinaryWriter wr = new BinaryWriter(File.OpenWrite(listBox1.SelectedItem.ToString()));
                wr.BaseStream.Position = 0x83C410;
                wr.Write(System.Text.Encoding.UTF8.GetBytes(textBox1.Text));
                wr.Close();
            }
