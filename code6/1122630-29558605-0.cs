    public Form1()
    {
                InitializeComponent();
    
                Size = new Size(400, 150);
                AutoSize = true;
                AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
    
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Size = new Size(200, 150);
                panel.MaximumSize = new System.Drawing.Size(panel.Width, int.MaxValue);
                panel.FlowDirection = FlowDirection.TopDown;
                panel.AutoSize = true;
                panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
                Controls.Add(panel);
    
                Label label = new Label();
                label.Text = "Starting text!\n";
                label.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
                label.AutoSize = true;
                panel.Controls.Add(label);
    
                ProgressBar progressBar = new ProgressBar();
                progressBar.Location = new Point(0, 125);
                progressBar.Size = new Size(190, 25);
                panel.Controls.Add(progressBar);
    
                Button button = new Button();
                button.Location = new Point(275, 50);
                button.Text = "Click me!";
                button.Click += (object sender, EventArgs e) => { label.Text += "some more text, "; };
                Controls.Add(button);
    }
