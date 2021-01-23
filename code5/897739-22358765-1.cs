    private void button1_Click(object sender, EventArgs e)
        {
            string drink = String.Empty;
            string burger = String.Empty;
            QtextBox1.Enabled = false; 
            QtextBox2.Enabled = false;
            QtextBox3.Enabled = false;
            StextBox1.Enabled = false;
            StextBox2.Enabled = false;
            StextBox3.Enabled = false;
            double sub1 = 0,sub2 = 0,sub3 = 0;
        if (checkBox1.Checked) //== true)
        {
            int q1;
            int.TryParse(QtextBox1.Text, out q1);
            sub1 = q1 * 4.99;
            StextBox1.Enabled = true;
            StextBox1.Text = sub1.ToString("c");
        }
        if (checkBox2.Checked)
        {
            int q2;
            int.TryParse(QtextBox1.Text, out q2);
            sub2 = q2 * 7.99;
            StextBox2.Enabled = true;
            StextBox2.Text = sub2.ToString("c");
        }
        if (checkBox3.Checked)
        {
            int q3;
            int.TryParse(QtextBox1.Text, out q3);
            sub3 = q3 * 5.99;
            StextBox3.Enabled = true;
            StextBox3.Text = sub3.ToString("c");
        }
        // get selected drink
        if (radioButton1.Checked)
            drink = "";
        else if (radioButton2.Checked)
            drink = "";
        else if (radioButton3.Checked)
            drink = "";
        textBox1.Text = mealsub.ToString();
        double tax = .098;
        string taxtotal = mealsub + tax;
        textBox2.Text = tax.ToString();
        textBox3.Text = taxtotal.ToString();
        textBox1.Text = (sub1 + sub2 + sub3).ToString();
    }
