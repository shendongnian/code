    RichTextBox T = new RichTextBox();
    t.Controls.Add(T);
    T.Dock = DockStyle.Fill;
    T.Font = new Font("Microsoft San Serif", 11);
    // Add this line
    T.BringToFront();
