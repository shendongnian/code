    private void button3_Click(object sender, EventArgs e)
        {
           try
            {
                timer1.Stop();
                if(saveFileDialog1.ShowDialog()== DialogResult.Ok)
                {
                   using(System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName))
                   {
                       StringBuilder sb = new StringBuilder(" Time and date:\r\n ");
                       sb.Append(Environment.NewLine);
                       sb.Append(textBox2.Text);
                       sb.Append(Environment.NewLine);
                       sb.Append(Environment.NewLine);
                       sb.Append(" Memory:");
                       sb.Append(Environment.NewLine);
                       sb.Append(textBox1.Text);
                       sb.Append(Environment.NewLine);
                       sb.Append(textBox10.Text);
                       ........
      
                       file.WriteLine(sb.ToString());
                  }
               }
               timer1.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
