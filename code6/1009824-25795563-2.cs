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
            if (sender == right_upDown)
            {
                this.AcceptButton = button_right;
                button_left.Click -= OnAcceptButtonClicked;  //Un-register the event from the left
                button_right.Click += new EventHandler(OnAcceptButtonClicked); //Register the event on the right
            }
            else
            {
                this.AcceptButton = button_left;
                button_right.Click -= OnAcceptButtonClicked; //Un-register the event from the right
                button_left.Click += new EventHandler(OnAcceptButtonClicked); //Register the event on the left
            }
        }
