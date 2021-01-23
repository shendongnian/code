    comboBox1.Text = "03:00";
    comboBox2.Text = "18:00";
    int t1 = Int32.Parse(comboBox1.Text.Replace(":", ""));
    int t2 = Int32.Parse(comboBox2.Text.Replace(":", ""));
    var comp = Int32.Compare(t1, t2);
