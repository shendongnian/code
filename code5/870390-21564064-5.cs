    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var panel = new ThreadedClock_ClassLibrary.ClockAnimationUsingThread();
            this.Controls.Add(panel);
            panel.Start();
        }
    }
