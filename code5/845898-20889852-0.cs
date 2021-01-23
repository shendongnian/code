        private YesNoMessageBoxResized newBoxResized;
        private string buttonClickResult;
        public void YesNoNewMessageBox(string title, string message,string buttonYes, string buttonNo)
        {
            YesNoMessageBoxResized msgResized = new YesNoMessageBoxResized(title, message, buttonYes, buttonNo);
            msgResized.StartPosition = FormStartPosition.CenterScreen;
            msgResized.TopMost = true;
            Button yesButtonResize = new Button();
            Button noButtonResize = new Button();
            //yes button
            yesButtonResize.Text = buttonYes;
            yesButtonResize.Size = new Size(150, 80);
            yesButtonResize.Font = new Font("Arial", 26);
            yesButtonResize.Location = new Point(100, 150);
            //no button
            noButtonResize.Text = buttonNo;
            noButtonResize.Size = new Size(150, 80);
            noButtonResize.Font = new Font("Arial", 26);
            noButtonResize.Location = new Point(300, 150);
            //make a copy of the current form
            newBoxResized = msgResized;
            //eventhandlers
            yesButtonResize.Click += YesButtonResizeClicked;
            noButtonResize.Click += noButtonResizeClicked;
            
            newBoxResized.Controls.Add(yesButtonResize);
            newBoxResized.Controls.Add(noButtonResize);
            newBoxResized.Show();
        }
        private void YesButtonResizeClicked(object o, EventArgs sEA)
        {
            this.buttonClickResult = "true";
            this.DoIfStatement();
            this.newBoxResized.Close();
        }
        private void noButtonResizeClicked(object o, EventArgs sEA)
        {
            this.buttonClickResult = "false";
            this.DoIfStatement();
            this.newBoxResized.Close();
        }
        private void DoIfStatement()
        {
            if (buttonClickResult == "true")
                this.restoreDefaults();
        }
        private void buttonRestoreDefaults_Click(object sender, EventArgs e)
        {
            YesNoNewMessageBox("Restore Defaults?", "Restore Defaults?", "Yes", "No");
        }
