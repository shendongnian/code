    CheckBox checkBoxA;
    CheckBox checkBoxB;
    
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        //Add checkbox A
        checkBoxA = new CheckBox();
        checkBoxA.Top = 10;
        checkBoxA.Left = 50;
        checkBoxA.Text = "CheckBoxA";
        //Register the event handler for this checkbox
        checkBoxA.Click += new EventHandler(checkBoxA_Click);
        this.Controls.Add(checkBoxA);
        //Add checkbox B
        checkBoxB = new CheckBox();
        checkBoxB.Top = 30;
        checkBoxB.Left = 50;
        checkBoxB.Text = "checkBoxB";
        //Register the event handler for this checkbox
        checkBoxB.Click += new EventHandler(checkBoxB_Click);
        this.Controls.Add(checkBoxB);        
    }
    void checkBoxA_Click(object sender, EventArgs e)
    {
        MessageBox.Show("CheckBoxA has been clicked!!!");
    }
    void checkBoxB_Click(object sender, EventArgs e)
    {
        MessageBox.Show("CheckBoxB has been clicked!!!");
    }
