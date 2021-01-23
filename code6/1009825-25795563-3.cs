        public Form1()
        {
            InitializeComponent();
            right_upDown.ValueChanged += new EventHandler(OnNumericUpDownValueChanged);
            left_upDown.ValueChanged += new EventHandler(OnNumericUpDownValueChanged);
            button_left.Click += new EventHandler(OnAcceptButtonClicked);
        }
        void OnAcceptButtonClicked(object sender, EventArgs e)
        {
        }
        void OnNumericUpDownValueChanged(object sender, EventArgs e)
        {
            this.AcceptButton -= OnAcceptButtonClicked;  //Un-register the event from the AcceptButton
            if (sender == right_upDown)
            {
                this.AcceptButton = button_right;
            }
            else
            {
                this.AcceptButton = button_left;
            }
            this.AcceptButton += new EventHandler(OnAcceptButtonClicked); //Register the event on new AcceptButton
        }
