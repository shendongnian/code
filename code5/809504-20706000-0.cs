            private void PlayGuessGame()
        {
            bool hasWon = false;
            int secretNumber = r.Next(1, 3);
            int tries = 1;
            messageTextBox.Text = "Guess a number";
            while (!hasWon)
            {
                autoEvent.WaitOne();
                if (guess == secretNumber) //if user wins
                {
                    this.Invoke(new MethodInvoker(delegate { messageTextBox.Text = "Congratulations! You've guess the correct number! It took {0} tries."; }));
                }
                else
                {
                    tries++;
                    if (guess < secretNumber)
                        this.Invoke(new MethodInvoker(delegate { messageTextBox.Text = "Guess higher!"; }));
                    else
                        this.Invoke(new MethodInvoker(delegate { messageTextBox.Text = "Guess lower!"; }));
                    this.Invoke(new MethodInvoker(delegate { lastGuessTextBox.Text = guess.ToString(); }));
                }
            }
        }
