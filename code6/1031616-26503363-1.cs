        if (!CheckBox1.Checked)
        {
            MyList = MyList.Where(a => a.Avg >= 2);
        }
        if (!CheckBox2.Checked)
        {
            MyList = MyList.Where(a => a.Avg < 2 || a.Avg >= 3);
        }
        if (!CheckBox3.Checked)
        {
            MyList = MyList.Where(a => a.Avg < 3 || a.Avg >= 6);
        }
        if (!CheckBox4.Checked)
        {
            MyList = MyList.Where(a => a.Avg < 6);
        }
