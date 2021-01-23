    private void button2_Click(object sender, EventArgs e)
    {
      string s = "";
      for(int i = 0; i < listBox1.Items.Count; i++)
      {
          s += listBox1.Items[i].ToString();
      }
    
      for(int i = 0; i < listBox2.Items.Count; i++)
      {
          s += listBox1.Items[i].ToString();
      }
    
      listBox3.Items.Add(s);
    }
