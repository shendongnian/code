    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string finalValue;
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                
                byte[] ascii = Encoding.ASCII.GetBytes(textBox1.Text);
                List<byte> newB = new List<byte>();
                foreach (byte b in ascii)
                {
                    byte s = b;
                    s++;
                    newB.Add(s);
                }
                finalValue = Encoding.ASCII.GetString(newB.ToArray());
            }
        }
