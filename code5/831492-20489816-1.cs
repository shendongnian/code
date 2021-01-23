    public class Form1 : Form
    {
            public Form1()
            {
                InitializeComponent();
                this.Load += Form1_Load;
            }
    
             void Form1_Load(object sender, EventArgs e)
            {
                label1.Text += Owner.Name;
            }
    }
