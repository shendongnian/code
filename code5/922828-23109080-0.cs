    namespace WindowsFormsApplication8
    {
     public partial class Form1 : Form
     {
        System.Timers.Timer myTimer = new System.Timers.Timer();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {  
            myTimer.Tick += myTimer_Tick;
            myTimer.Interval = 1000;
            myTimer.Start();
        }
        void myTimer_Tick(object sender, EventArgs e)
        {      
            System.Threading.Thread.Sleep(5000); // 5000 is 5 seconds. i.e. after 5 seconds i am changing the cursor position. 
            MoveCursor();
        }
        private void MoveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 10, Cursor.Position.Y - 10);
        }
     }
    }
