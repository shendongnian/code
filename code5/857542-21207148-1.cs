    int top = 50;
    int left = 100;
    for (int i = 0; i < 10; i++)
    {
        Button button = new Button();
        button.Left = left;
        button.Top = top;
        panel.Controls.Add(button); // here
        top += button.Height + 2;
    }
