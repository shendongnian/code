    public void button1_Click(object sender, EventArgs e)
    {
        if (textBox2 == null)
        {
            MessageBox.Show("please enter employee name");
        }
        else
        {
            // Create a new instance in the array
            GlobalVariable.staff[GlobalVariable.total] = new Employeeclass();
            GlobalVariable.staff[GlobalVariable.total].id = 
              Convert.ToInt32(textBox1.Text);
            GlobalVariable.staff[GlobalVariable.total].name = textBox2.Text;
            GlobalVariable.staff[GlobalVariable.total].salary = 0.0;
            GlobalVariable.total++;  
        }
        this.Close();
    }
