        public Form1()
        {
            InitializeComponent();
            // create the controller
            var rpc = new ResizingPanelController();
            // add the panel to the form - the form has already two buttons
            this.Controls.Add(rpc.PanelControl);
            // set panel size
            rpc.PanelControl.SetBounds(10, 10, 200, 200);
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
            rpc.PanelControl.Controls.Add(buttonPlus);
            rpc.PanelControl.Controls.Add(buttonMinus);
            rpc.PanelControl.Controls.Add(label);
            // resize panel
            this.buttonClosePanel.Click += (s, e) =>
                {
                    // make it smaller
                    rpc.ResizeControl(-170);
                };
            this.buttonOpenPanel.Click += (s, e) =>
            {
                // make it bigger
                rpc.ResizeControl(170);
            };
        }
