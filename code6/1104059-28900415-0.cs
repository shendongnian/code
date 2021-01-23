    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        char Key = 'A';
        for (int i = 0; i < 10; i++)
        {
            Button button = new Button();
            button.Tag = Key + i;
            button.Width = 100;
            button.Height = 100;
            button.Content = (char)(Key + i);
            button.Click += button_Click;
            stackPanel1.Children.Add(button);
        }
        for (int i = 11; i < 20; i++)
        {
            Button button = new Button();
            button.Tag = Key + i;
            button.Width = 100;
            button.Height = 100;
            button.Content = (char)(Key + i);
            button.Click += button_Click;
            stackPanel2.Children.Add(button);
        }
        for (int i = 21; i < 26; i++)
        {
            Button button = new Button();
            button.Tag = Key + i;
            button.Width = 100;
            button.Height = 100;
            button.Content = (char)(Key + i);
            button.Click += button_Click;
            stackPanel3.Children.Add(button);
        }
    }
    //Now use a switch case to get the TAG property
    private void button_Click(object sender, RoutedEventArgs e)
    {
        var t = (sender as Button).Tag;
        char tag = Convert.ToChar(t);
        switch (tag)
        {
        case 'A':
            console.Text = "You typed " + tag;
            //Your code logic
            break;
        case 'B':
            console.Text = "You typed " + tag;
            //Your code logic
            break;
        case 'C':
            console.Text = "You typed " + tag;
            //Your code logic
            break;
	//Rest of the alphabets
        }
    }
