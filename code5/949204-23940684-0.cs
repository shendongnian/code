     private void button1_Click(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    label1.Text = openFileDialog1.FileName;
                    //till here the same
                    //open filestream
                    System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                    //loop trough lines
                    while ((line = file.ReadLine()) != null)
                    {
                        //add line to listbox
                        listBox1.Items.Add ( File.ReadAllText(line));
                    }
                }
            }
