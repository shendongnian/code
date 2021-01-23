    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
    
                for (int i = 1; i < 13; i++)
                {
                    panel1.Controls.Add(new Label
                    {
                        Location = new Point(10, 10+(i*30)), 
                        Text = i.ToString()
                    });
    
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                panel1.Controls.Clear();
            }
        }
    }
