      private void btnReverse_Click(object sender, EventArgs e)
        {
            ArrayList list=new ArrayList();
            foreach (var i in comboBox1.Items)
            {
                list.Add(i);
            }
            
            list.Reverse();
            comboBox1.DataSource = list;
        }
