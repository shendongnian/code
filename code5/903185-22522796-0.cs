    MessagePrompt msgPrompt = new MessagePrompt();
    msgPrompt.Message = "Your Message.";
    Button yesBtn = new Button() { Content = "Yes" };
    yesBtn.Click += new RoutedEventHandler(yesBtn_Click);
    Button noBtn = new Button() { Content = "No" };
    noBtn.Click += new RoutedEventHandler(noBtn_Click);
    msgPrompt.ActionPopUpButtons.Add(noBtn);
    msgPrompt.ActionPopUpButtons.Add(yesBtn);
    msgPrompt.Show();
