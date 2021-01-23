        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string line;
 
            string lines = textBox1.Text;
                StreamWriter file2 = new StreamWriter("D:\\test.txt",true);
                file2.WriteLine(lines);
                file2.Close();
            string text = textBox2.Text;
            StreamReader file3 = new StreamReader("D:\\test.txt");
            while ((line = file3.ReadToEnd()) != null)
            {
                if (line.Contains(text))
                {
                    MessageBox.Show("Name "+text+" is Found!");
                   textBox2.Text = text;
                    
                    break;
                }
                counter++;
            }
            file3.Close();
        
        }
