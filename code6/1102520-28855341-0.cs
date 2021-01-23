        public Form1()
        {
            InitializeComponent();
            InitCustomButtons();
        }
        private void InitCustomButtons()
        {
            this.InitCustomButtonsRecursive(this);
        }
        private void InitCustomButtonsRecursive(Control container)
        {
            if (container is Button)
            {
                container.Enter += ColorButtonOnEnter;
            }
            for (var i = 0; i < container.Controls.Count; i++)
            {
                var control = container.Controls[i];
                InitCustomButtonsRecursive(control);
            }
        }
        private void ColorButtonOnEnter(object sender, EventArgs eventArgs)
        {
            var button = sender as Button;
            if (button != null)
            {
                button.BackColor = Color.Blue;
            }
        }
