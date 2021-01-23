    private void buttonRecordBytes_Click(object sender, EventArgs e)
        {
            // Break if textbox1 is empty.
            if (string.IsNullOrEmpty(textbox1.Text))
                return;
            // Variables:
            int charCount = textbox1.Text.Length;
            byte[] bytes = new byte[charCount];
            string[] byteStrings = new string[charCount];
            // StreamWriter will write the bytes to the text file.
            StreamWriter sw = new StreamWriter("PathOfYourTextFile.txt", true);
            // Record each character byte in textfile.
            int i = 0;
            foreach (char c in textbox1.Text)
            {
                // ASCII:
                try
                {
                    bytes[i] = Convert.ToByte(c);
                    byteStrings[i] = Convert.ToString(bytes[i], 2).PadLeft(8, '0');
                }
                // UTF8:
                catch
                {
                    bytes[i] = Encoding.UTF8.GetBytes(c.ToString().ToCharArray())[i];
                    byteStrings[i] = Convert.ToString(bytes[i], 2).PadLeft(24, '0');
                }
                // Append character and bit info to textfile.
                sw.WriteLine("Character \"" + c.ToString() + "\" bits as ones and zeros: " +
                    byteStrings[i]);
                ListViewItem lvi = new ListViewItem(i.ToString());
                lvi.SubItems.Add(c.ToString());
                lvi.SubItems.Add(byteStrings[i]);
                listviewBytes.Items.Add(lvi);
                i++;
            }
        sw.Close();
        }
