    public partial class Form1 : Form
    {
        private Random _Random;
        private List<TimeSpan> _ReactionTimes;
        private Stopwatch _Stopwatch;
        public Form1()
        {
            InitializeComponent();
            _Stopwatch = new Stopwatch();
            _Random = new Random(42);
            _ReactionTimes = new List<TimeSpan>();
        }
        private Button CreateButton(Color color)
        {
            var button = new Button();
            button.Click += OnColorButtonClick;
            button.BackColor = color;
            button.Text = color.Name;
            return button;
        }
        private Button GetRandomButton()
        {
            var randomIndex = _Random.Next(0, flowLayoutPanel.Controls.Count);
            return (Button)flowLayoutPanel.Controls[randomIndex];
        }
        private Color GetRandomColor()
        {
            var randomKnownColor = (KnownColor)_Random.Next((int)KnownColor.AliceBlue, (int)KnownColor.ButtonFace);
            return Color.FromKnownColor(randomKnownColor);
        }
        private void InitializeColorButtons(int numberOfColors)
        {
            var buttons = Enumerable.Range(1, numberOfColors)
                                    .Select(index => GetRandomColor())
                                    .Select(color => CreateButton(color));
            foreach (var button in buttons)
            {
                flowLayoutPanel.Controls.Add(button);
            }
        }
        private void OnButtonStartClick(object sender, EventArgs e)
        {
            InitializeColorButtons((int)numericUpDownColors.Value);
            StartMeasurement();
        }
        private void OnColorButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            if (button.Text != labelColorToClick.Text)
            {
                errorProviderWrongButton.SetIconPadding(button, -20);
                errorProviderWrongButton.SetError(button, "Sorry, wrong button.");
                return;
            }
            StopMeasurement();
            _ReactionTimes.Add(_Stopwatch.Elapsed);
            UpdateSummary();
        }
        private void StartMeasurement()
        {
            buttonStart.Enabled = false;
            numericUpDownColors.Enabled = false;
            labelColorToClick.Text = GetRandomButton().Text;
            _Stopwatch.Reset();
            _Stopwatch.Start();
        }
        private void StopMeasurement()
        {
            _Stopwatch.Stop();
            errorProviderWrongButton.Clear();
            flowLayoutPanel.Controls.Clear();
            numericUpDownColors.Enabled = true;
            buttonStart.Enabled = true;
            labelColorToClick.Text = String.Empty;
        }
        private void UpdateSummary()
        {
            labelSummary.Text = String.Format("Current: {0:0.000}    Minimum: {1:0.000}    Maximum: {2:0.000}", _ReactionTimes.Last().TotalSeconds, _ReactionTimes.Min().TotalSeconds, _ReactionTimes.Max().TotalSeconds);
        }
    }
