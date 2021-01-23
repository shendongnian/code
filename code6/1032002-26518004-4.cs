    List<Button> buttonList = new List<Button>();
        for (int i = 0; i < 2; i++)
        {
            Button test = new Button();
            test.Text = i.ToString();
            test.Click += new EventHandler(ButtonClick);
            placeholder.Controls.Add(test);
        }
