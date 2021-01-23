    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _enemy = new Enemy( this );
        }
        private Enemy _enemy;
    }
