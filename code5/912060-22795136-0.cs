    for (var i = 0; i < 5; i++)
    {
        var panel = new Panel { BorderStyle = BorderStyle.FixedSingle, Width = 100, BackColor = Color.LightBlue };
        panel.Controls.AddRange(
            new Control[]
        {
            new Label { Text = "Title", Location = new Point(0, 0) },
            new Label { Text = "Subtitle", Location = new Point(0, 25) }
        });
        flowLayoutPanel1.Controls.Add(panel);
    }
