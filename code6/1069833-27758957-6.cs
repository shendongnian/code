        public Form1()
        {
            InitializeComponent();
            // add controls to the panel
            var buttonPlus = new Button();
            var buttonMinus = new Button();
            var label = new Label();
            buttonPlus.Text = "+";
            buttonMinus.Text = "-";
            label.Text = "Something to Show!";
            buttonPlus.SetBounds(1, 1, 50, 25);
            buttonMinus.SetBounds(1, 26, 50, 25);
            label.SetBounds(1, 51, 200, 25);
            panel1.Controls.Add(buttonPlus);
            panel1.Controls.Add(buttonMinus);
            panel1.Controls.Add(label);
            // resize panel
            this.buttonClosePanel.Click += (s, e) =>
                {
                    // make it smaller
                    resizeControl(-250);
                };
            this.buttonOpenPanel.Click += (s, e) =>
            {
                // make it bigger
                resizeControl(250);
            };
        }
        private async void resizeControl(int delta)
        {
            var y = panel1.Size.Height;
            var x = this.panel1.Size.Width;
            // do we need to increase or decrease
            var up = delta > 0;
            // set condition end regarding resize direction (make x bigger or smaller)
            var end = up ? x + delta : x - Math.Abs(delta);
            // evaluate condition regarding resize direction
            Func<int, int, bool> conditionIsMet = (value, limit) => up ? value < limit : value > limit;
            while (conditionIsMet(x, end))
            {
                // increase or decrease x regarding resize direction
                x = up ? x + 1 : x - 1;
                this.panel1.Size = new Size(x, y);
                await Task.Delay(10);
                // repaint controls for smooth view
                this.panel1.Refresh();
            }
        }
