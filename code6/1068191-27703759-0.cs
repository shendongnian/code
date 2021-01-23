    Panel panel = new Panel();
    panel.Size = new Size(300, 100);
    panel.Dock = DockStyle.Bottom;
    
    Button button = new Button();
    button.Size = new Size(70, 25);
    button.Location = new Point((panel.Width - button.Width) / 2, (panel.Height - button.Height) / 2);
    button.Anchor = AnchorStyles.None;
    
    panel.Controls.Add(button);
    this.Controls.Add(panel);
