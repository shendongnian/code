    if (checkBox1.Checked) //== true)
    {        
        int q1;
        int.TryParse(QtextBox1.Text, out q1);        
        double sub1 = q1 * 4.99; //sub1 being created here
        StextBox1.Enabled = true;
        StextBox1.Text = sub1.ToString("c");
    }//sub1 does not exist here
    if (checkBox2.Checked)
    {        
        int q2;
        int.TryParse(QtextBox1.Text, out q2);
        double sub2 = q2 * 7.99; //sub2 being created here
        StextBox2.Enabled = true;
        StextBox2.Text = sub2.ToString("c");
    }//sub2 does not exist here
    if (checkBox3.Checked)
    {
        
        int q3;
        int.TryParse(QtextBox1.Text, out q3);
        double sub3 = q3 * 5.99; //sub3 being created here
        StextBox3.Enabled = true;
        StextBox3.Text = sub3.ToString("c");
    }//sub3 does not exist here
