    namespace GeometryTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                button1.Click += new System.EventHandler(button1_Click);
            }
           private void Form1_Load(object sender, EventArgs e)
           {
           } 
          
            private void button1_Click(object sender, EventArgs e)
            {
                System.Drawing.Graphics gr = this.CreateGraphics();
                gr.Clear(Color.White);
                Pen pen = new Pen(System.Drawing.Color.Red,3);
                gr.DrawLine(pen, 20, 20, 200, 250);
            }
        }
    }
