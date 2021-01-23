       using statements...
        
        namespace WindowsFormsApplication1
        {
        <remove your code and place the code below here>
        }
    
         public partial class Form1 : Form
            {
                const double pi = 3.14159;
        
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
        
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    double radius;
                    double.TryParse(textBox1.Text, out radius);
                    var area = pi * radius * radius;
                    outputBox.Text = string.Format("{0}", area);
                }
        
            }
