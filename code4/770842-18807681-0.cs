    List<CheckBox> CheckBoxes = new List<CheckBox>();
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        CreateCheckBoxes();
    }
    private void CreateCheckBoxes()
    {
        //Create 3 checkboxes
        int intialTop = 50;
        for (int i = 0; i < 3; i++)
        {
            CheckBox chk = new CheckBox();
            chk.Top = intialTop;
            chk.Left = 50;
            chk.Text = "Check Box Test";
            chk.Name = "chkTest";
            this.Controls.Add(chk);
            CheckBoxes.Add(chk);
            intialTop += 20;
        }
        //You can access your checkboxes anywhere in Form1 now.
        var first = CheckBoxes.First();
        first.Text = "First Checkbox";
    }
