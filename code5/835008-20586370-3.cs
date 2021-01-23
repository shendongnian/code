            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection cn = new OleDbConnection();
            OleDbDataReader dr;
    
           private void listBox2_Click(object sender, EventArgs e)
            {
                ListBox l = sender as ListBox;  
                if(l.SelectedIndex!=-1)
                textBox2.Text = l.SelectedItem.ToString();
            }
    
            }
    
           private void button1_Click(object sender, EventArgs e)
            {
                if (textBox1.Text != "")
                {
                    string q = "insert into Table1(name) values ('"+textBox1.Text.ToString()+"')";
                    doSomething(q);
                    textBox1.Text = null;
                }
            }
    
           private void button2_Click(object sender, EventArgs e)
            {
                if (listBox1.SelectedIndex != -1)
                {
                    string q = "delete from Table1 where id=" + listBox1.SelectedItem.ToString();
                    doSomething(q);
                }
            }
    
           private void button3_Click(object sender, EventArgs e)
            {
                if (textBox2.Text != "" & listBox1.SelectedIndex != -1)
                {
                    string q = "update Table1 set [name] ='" + textBox2.Text.ToString() + "' where id =" + listBox1.SelectedItem.ToString();
                    doSomething(q);
                    textBox2.Text = "";
                }
            }
    
    
           private void doSomething(String q)
            {
                try
                {
                    cn.Open();
                    cmd.CommandText = q;
                    cmd.Connection=cn;
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    loaddata();
                }
                catch (Exception e)
                {
                    cn.Close();
                    MessageBox.Show(e.Message.ToString());
                }
            }
