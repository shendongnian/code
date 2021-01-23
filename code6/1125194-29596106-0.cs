    private void Form1_Load(object sender, EventArgs e)
    {
        //Move to Form1_Activated
    }
    private void Form1_Activated(object sender, EventArgs e)
    {
        int n = dataGridView1.Rows.Add();
        dataGridView1.Rows[n].Cells[0].Value = name;
        dataGridView1.Rows[n].Cells[1].Value = lastName;
        dataGridView1.Rows[n].Cells[2].Value = age;
        dataGridView1.Rows[n].Cells[3].Value = gender;
    }
    private void addTask_Click(object sender, EventArgs e)
    {
        Form2 f2 = new Form2(); //show form2 so user can input data
        f2.ShowDialog(this);//set this form as Owner
    }
