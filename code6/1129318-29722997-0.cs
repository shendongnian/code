    public partial class Form_TransparentBack : Form
    {
        public Form_TransparentBack()
        {
            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.WhiteSmoke;
            Opacity = 0.5;
            Timer timer = new Timer() { Interval = 10};
            timer.Tick += delegate(object sn, EventArgs ea)
            {
                (sn as Timer).Stop();
                new Foreground_Form().ShowDialog();
            };
            timer.Start();
        }
    }
