    public Form1()
    {
        InitializeComponent();
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
    }
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
                ProcessTabKey(true);//this will move textbox focus on Enter Key pressed.
        } 
        else if (e.KeyCode == Keys.Back)
        {
            BackSpaceButton_Click(null,null);//this is a button event,it fire when you press Back key
        }
    }
