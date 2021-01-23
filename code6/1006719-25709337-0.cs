    public Form1()
    {
        InitializeComponent();
        textBox1.Font = new System.Drawing.Font("Consolas", 32f); 
        G = textBox1.CreateGraphics();
        for (int i = 0; i < 100; i++) textBox1.Text += i.ToString("0123456789");
    }
    Graphics G;
    private void button2_Click(object sender, EventArgs e)
    {   
       for (int i = 0; i < 10; i++) textBox1.Text += i.ToString("x");
       Console.WriteLine( textBox1.Text.Length.ToString("#0   ") 
           + G.MeasureString(textBox1.Text, textBox1.Font).Width);
    } 
