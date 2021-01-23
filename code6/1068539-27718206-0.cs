    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var sampleForm = new Form() { AutoScroll = true };
		Panel panel = new Panel() { BackColor = Color.Red, AutoSizeMode = AutoSizeMode.GrowAndShrink, AutoSize = true };
		Button btn = new Button { Text = "Toggle MinSize", AutoSize = true };
		panel.Controls.Add(btn);
		btn.Click += delegate {
			if (panel.MinimumSize == Size.Empty)
				panel.MinimumSize = new Size(600,600);
			else
				panel.MinimumSize = Size.Empty;
		};
        sampleForm.Controls.Add(panel);
        Application.Run(sampleForm);
    }
