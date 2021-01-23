            private void userTextBox_TextChanged(object sender, EventArgs e)
        {
            var userInput = userTextBox.Text;
            charCountOutput.Text = userInput.Length.ToString();
        }
