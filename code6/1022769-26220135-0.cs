        private void securityCheck()
        {
            if (MyGlobals.FormCheck("RUN_JOBS") == 1)
            {
                InitializeComponent();
            }
            else
            {
                Label message = new Label();
                message.Dock = DockStile.Fill;
                message.Text("You do not have permission to access this form!.");
                message.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(message);
            }      
        }
