     private int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = String.Format("File {0}: {1}", i+1, files[i]);
            i++;
            if (i == files.Length)
            {
                textBox1.Text == "Total Files: " + i;
                tm.Stop();
            }
        }
