        public Form1()
        {
            InitializeComponent();
            InitCustomButtons();
        }
        private void InitCustomButtons()
        {
            this.InitCustomButtonsRecursive(this);
        }
        private Dictionary<Button, Color> _originalColors = new Dictionary<Button, Color>(); 
        private void InitCustomButtonsRecursive(Control container)
        {
            if (container is Button)
            {
                container.MouseEnter += ColorButtonEnter;
                container.MouseLeave += ColorButtonLeave;
            }
            for (var i = 0; i < container.Controls.Count; i++)
            {
                var control = container.Controls[i];
                InitCustomButtonsRecursive(control);
            }
        }
        private void ColorButtonLeave(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (_originalColors.ContainsKey(button))
                {
                    button.BackColor = _originalColors[button];
                }
                
            }
        }
        private void ColorButtonEnter(object sender, EventArgs eventArgs)
        {
            var button = sender as Button;
            if (button != null)
            {
                _originalColors[button] = button.BackColor;
                button.BackColor = Color.Blue;
            }
        }
