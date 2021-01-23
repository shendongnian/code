    public partial class Form_TransparentBack : Form
    {
        public Form_TransparentBack(Form _foregroundForm)
        {
            InitializeComponent();
            StartPosition = _foregroundForm.StartPosition;
            Location = _foregroundForm.Location;
            Size = _foregroundForm.Size;
            _foregroundForm.Resize += _foregroundForm_Resize;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _foregroundForm.LocationChanged += _foregroundForm_LocationChanged;
            ShowInTaskbar = false;
            BackColor = Color.WhiteSmoke;
            Opacity = 0.5;
            Timer timer = new Timer() { Interval = 10};
            timer.Tick += delegate(object sn, EventArgs ea)
            {
                (sn as Timer).Stop();
                _foregroundForm.ShowDialog();
            };
            timer.Start();
            ShowDialog();
        }
        void _foregroundForm_LocationChanged(object sender, EventArgs e)
        {
            Location = (sender as Form).Location;
        }
        void _foregroundForm_Resize(object sender, EventArgs e)
        {
            Size = (sender as Form).Size;
        }
    }
