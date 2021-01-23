    public partial class Form1 : Form
    {
        static Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            System.Threading.Tasks.Task.Factory.StartNew(changetextfromanotherthread);
        }
        void changetextfromanotherthread()
        {
            for (int x = 0; x < 100; x++)
            {
                Invoke((Action)(() => { textBox1.Text = "" + rand.Next(); }));
                System.Threading.Thread.Sleep(250);
            }
               
        }
    }
