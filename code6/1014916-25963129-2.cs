    public partial class Natural : Form
    {
        public Natural()
        {
            InitializeComponent();
            _actions = new Action[]
            {
                Number2Action,
                OtherAction,
                OtherAction
            };
        }
        private readonly Random _random=new Random();
        private int _number2 = 0;
        private int _currentNumber = 0;
        private readonly Action[] _actions;
        private void Number2Action()
        {
            _number2++;
            txtNumber2.Text = _number2.ToString();
        }
        private void OtherAction()
        {
            txtnumber.Text = _currentNumber.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _currentNumber = _random.Next(1,7);
            var chose = _currentNumber;
            chose -= 3; //mod (2-3)=-1
            chose %= 2;
            chose++;
            _actions[chose].Invoke();
        }
    }
