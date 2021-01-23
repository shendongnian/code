    public partial class Form1 : Form
        {
            public Form2 Form2GlobalInstance { get; set; }
            public Form1()
            {
                InitializeComponent();
                Form2GlobalInstance = new Form2();
                Thread newThread = new Thread((ThreadStart)delegate { Application.Run(Form2GlobalInstance); });
                newThread.Start();
                Load += delegate
                {
                    var frm2Location = Form2GlobalInstance.GetLocation();
                    MessageBox.Show("location.x=" + frm2Location.X + " location.y=" + frm2Location.Y);
                };
            }
    
        }
