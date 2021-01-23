    private string carKey;  // member variable to store the key
    private void button3_Click(object sender, EventArgs e)
    {
        int i;
        i = dataGridView1.SelectedCells[0].RowIndex;
        textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
        textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        carKey = textBox1.Text;  // store the key of the selected car
    }
    private void button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Dido\documents\visual studio 2012\Projects\CourseProjectCars\CourseProjectCars\DataCars.mdf;Integrated Security=True;Connect Timeout=30");
        con.Open();
        SqlCommand cmd = new SqlCommand("Update SuperCars set Car=@Car,mph=@mph,price=@price Where(Car=@CarKey)", con);
        cmd.Parameters.AddWithValue("@Car", textBox1.Text);
        cmd.Parameters.AddWithValue("@mph", textBox2.Text);
        cmd.Parameters.AddWithValue("@price", textBox3.Text);
        cmd.Parameters.AddWithValue("@CarKey", carKey);  // use the stored car key
        cmd.ExecuteNonQuery();
        MessageBox.Show("updated......");
        con.Close();
        Bind();
        Clear();
    }
