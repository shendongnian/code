    public Form1()
    {
        InitializeComponent();
        foreach (TextBox txtBox in panel1.Controls)
        {
            txtBox.TextChanged += textBox_TextChanged;
        }
    }
