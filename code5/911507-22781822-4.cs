    for (int i = 0; i < 10; i++)
    {
        var button = new Button {Text = "Button " + i};
        CustomControl c = new CustomControl(button, new Label {Text = "Label!"});
        button.Click += buttonClicked;
        fl_panel.Controls.Add(c);
    }
    ...
    private void buttonClicked(object sender, EventArgs e)
    {
        MessageBox.Show(((Button) sender).Text);
    }
    
