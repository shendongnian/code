                // Populate dictionary
            Dictionary<Button, Color> myButtons = new Dictionary<Button, Color>();
            myButtons.Add(button1, Color.Red);
            myButtons.Add(button2, Color.Blue);
            myButtons.Add(button3, Color.Green);
            myButtons.Add(button4, Color.Purple);
            myButtons.Add(button5, Color.Pink);
            myButtons.Add(button6, Color.PaleVioletRed);
            // Get first untouched occurrence
            var buttonToBeChanged = myButtons.Reverse().FirstOrDefault(x => x.Key.BackColor.IsSystemColor);
            // No buttons left
            if (buttonToBeChanged.Key == null)
                MessageBox.Show("No buttons left!");
            else
                buttonToBeChanged.Key.BackColor = buttonToBeChanged.Value;
