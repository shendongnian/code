    private void button2_Click(object sender, EventArgs e)
    {
      string s = "";
      for(int i = 0; i < listBox1.Items.Count; i++)
      {
          s += listBox1.Items[i].ToString() + " ";
      }
    
      for(int j = 0; j < listBox2.Items.Count; j++)
      {
          s += listBox1.Items[j].ToString() + " ";
      }
    
      listBox3.Items.Add(s.Trim());
    }
