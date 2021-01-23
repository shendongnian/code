    private void Form1_Load(object sender, EventArgs e)
            {
                ResultLabel.Bind(NameTextBox);
                WarningLabel.Bind(NameTextBox,i => i.Length == 0 ? "field required!" : "");
                SendButton.Bind(NameTextBox, i => SendButton.Enabled = !(i.Length == 0));
            }
