    namespace GeometryTest
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                    this.Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
                }
    
    
               private void Form1_Load(object sender, EventArgs e)
               {
    
               } 
              
                private void Form1_Paint(object sender, PaintEventArgs e)
               {
    
                System.Drawing.Graphics gr = this.CreateGraphics();
                gr.Clear(Color.White);
                Pen pen = new Pen(System.Drawing.Color.Red, 3);
                gr.DrawLine(pen, 20, 20, 200, 250);
                
                }
            }
        }
