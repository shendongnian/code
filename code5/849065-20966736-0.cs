    private void button1_Click(object sender, EventArgs e)
        {
            int totalPrice = 0;
            for(int i=0;i<listView1.Items.Count;i++)
            {
                totalPrice += Convert.ToInt32(listView1.Items[i].SubItems[2].Text);
            }
            
        }
