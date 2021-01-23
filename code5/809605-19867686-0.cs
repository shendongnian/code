    List<processing> list = new List<processing>(); // at class level.
    private void button1_Click(object sender, EventArgs e)
    {
            processing pr = new processing();
            pr.process = p.Text;
            pr.arrivaltime = Int32.Parse(AT.Text);
            pr.bursttime = Int32.Parse(BT.Text); 
             list.Add(pr); //add item to class level list
            dataGridView1.DataSource = list; //update the data source
    }
