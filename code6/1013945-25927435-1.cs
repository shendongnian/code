        public static string mInputBox(string strPrompt, string strTitle, string strDefaultResponse)
        {
            string strResponse = null;
            Form inputBox = new Form();
            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            inputBox.ClientSize = new Size(500, 85);
            inputBox.Text = strTitle;
            inputBox.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            inputBox.Left = (Screen.PrimaryScreen.Bounds.Size.Width/2) - (inputBox.ClientSize.Width/2);
            inputBox.Top = (Screen.PrimaryScreen.Bounds.Size.Height/2) - (inputBox.ClientSize.Height/2);
            Label lblPrompt = new Label();
            lblPrompt.Text = strPrompt;
            inputBox.Controls.Add(lblPrompt);
            TextBox textBox = new TextBox();
            textBox.Text = strDefaultResponse;
            inputBox.Controls.Add(textBox);
            Button okButton = new Button();
            okButton.Text = "&OK";
            inputBox.Controls.Add(okButton);
            Button cancelButton = new Button();
            cancelButton.Text = "&Cancel";
            inputBox.Controls.Add(cancelButton);
            okButton.Click += (sender, e) =>
            {
                strResponse = textBox.Text;
                inputBox.Close();
            };
            cancelButton.Click += (sender, e) =>
            {
                inputBox.Close();
            };
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;
            var formActive = true;
            inputBox.FormClosed += (s, e) => formActive = false;
            inputBox.Show();
            inputBox.TopMost = true;
            inputBox.Activate();
            while (formActive)
            {
                Thread.Sleep(10);
                Application.DoEvents();
            }
            return strResponse;
        }
