    private void button1_Click(object sender, EventArgs e)
        {
            int tid;
            tid = Convert.ToInt32(textBox1.Text);
            
    foreach(var item in sekunder(tid))
     {
     MessageBox.Show(Convert.ToString(item ));
     // for comma separated 
     //use this : MessageBox.Show(string.Join(",",sekunder(tid)))
     }
    }
