            Button button = sender as Button;
            var resultString = Regex.Match(button.Name, @"\d+").Value;
            Control[] matches = this.Controls.Find("radioButtonTimer"+resultString+"_CountDown", true);
            if (matches.Length > 0 && matches[0] is RadioButton)
            {
                RadioButton rb = matches[0] as RadioButton;
                if (rb.Checked)
                {
                    // ... do something in here ...
                }
            }
