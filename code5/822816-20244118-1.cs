    protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox aTextBox = new TextBox();
            aTextBox.ID = "helloText";
            Button aButton = new Button();
            aButton.ID = "helloButton";
            aButton.Click += aButton_Click;
            aButton.Text = "helloButton";
            form1.Controls.Add(aTextBox);
            form1.Controls.Add(aButton);
        }
        void aButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
