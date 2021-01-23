            using (BinaryReader reader = new BinaryReader(new FileStream("file.bin", FileMode.OpenOrCreate)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Count = reader.ReadInt32();  Count++; 
                }
            }
            if (Count % 5 == 0)
            {
                MessageBox.Show(Count.ToString());
            }
        }
        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream("file.bin", FileMode.Open)))
            {
                writer.Write(Count); 
            }
        }
