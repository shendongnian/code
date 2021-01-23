            // Add ButtonStackPanel
            StackPanel ButtonStackPanel = new StackPanel();
            ButtonStackPanel.Name = "ButtonStackPanel";
            // Add Buttons
            while (await statement.StepAsync())
            {
              Button button = new Button();
              button.Click += this.disease_Click;
              button.Content = Names[statement.GetTextAt(0)];
              button.FontSize = 28;
              button.Height = 80;
              ButtonStackPanel.Children.Add(button);
            }
            MainStackPanel.Children.Insert(2, ButtonStackPanel);
