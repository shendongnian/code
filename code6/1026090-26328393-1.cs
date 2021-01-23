            char userGuess = Convert.ToChar(textBox1.Text);
            char[] displayAnswer = answerLabel.Text.ToCharArray();
            for (int n = 0; n < displayAnswer.Length; n++)
            {
                if (guessThis[n] == userGuess)
                {
                    displayAnswer[n] = userGuess;
                    }
            }
            answerLabel.Text = new string(displayAnswer);
