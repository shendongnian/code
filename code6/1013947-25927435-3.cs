    class Inputbox : Form
    {
        public string Response { get; set; }
        public Inputbox(string strTitle, string strPrompt, string strDefaultResponse)
        {
            //add UI and Controls here
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            ClientSize = new Size(500, 85);
            Text = strTitle;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Left = (Screen.PrimaryScreen.Bounds.Size.Width/2) - (ClientSize.Width/2);
            Top = (Screen.PrimaryScreen.Bounds.Size.Height/2) - (ClientSize.Height/2);
            Label lblPrompt = new Label();
            lblPrompt.Text = strPrompt;
            Controls.Add(lblPrompt);
            TextBox textBox = new TextBox();
            textBox.Text = strDefaultResponse;
            Controls.Add(textBox);
            Button okButton = new Button();
            okButton.Text = "&OK";
            Controls.Add(okButton);
            Button cancelButton = new Button();
            cancelButton.Text = "&Cancel";
            Controls.Add(cancelButton);
            okButton.Click += (sender, e) =>
            {
                Response = textBox.Text;
                Close();
            };
            cancelButton.Click += (sender, e) =>
            {
                Close();
            };
            AcceptButton = okButton;
            CancelButton = cancelButton;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TopMost = true;
            Activate();
        }
    }
    public static string mInputBox(string strPrompt, string strTitle, string strDefaultResponse)
    {
        string strResponse = null;
        Inputbox inputBox = new Inputbox(strPrompt,strTitle,strDefaultResponse);
       
        inputBox.ShowDialog();
        return inputBox.Response;
    }
