         private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
          {  
                if(textBox1.Text !="")
            {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Text="";
            }
          }
     }
        private void button1_Click(object sender, EventArgs e)
        {
            int i, n;
            double x, m;
            n = listBox1.Items.Count;
            m = 0;
            for (i=0;i<n;i++)
        {
                x=Convert.ToDouble(listBox1.Items[i]);
                m = m + x;
           }   
            textBox2.Text=Convert.ToString(m);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
    }
        }
