    ListBox listBox1 = new ListBox();
    List<double> doubleList = new List<double>() {1.0, 1.2, 1.3 };
    int curInt = 1;
    listBox1.DataSource = doubleList;
    listBox1.Tag = curInt;
    listBox1.Click +=new EventHandler(listBox_Click);
    
    ListBox listBox2 = new ListBox();
    doubleList = new List<double>() { 2.0, 2.2, 2.3 };
    curInt = 2;
    listBox2.DataSource = doubleList;
    listBox2.Tag = curInt;
    listBox2.Click += new EventHandler(listBox_Click);
    
    this.Controls.Add(listBox1);
    this.Controls.Add(listBox2);
