    Robot robot1;
    public Form1()
    {
        InitializeComponent();
        label2.Location = new Point(100,100);
        label1.Text = label2.Location.ToString();
        robot1 = new Robot(this); // "this" is the Form1 instance        
    }
