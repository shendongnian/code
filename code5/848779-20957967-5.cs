    class ModalPanel : Panel
    {
        protected readonly Button okButton;
        Task task;
        public ModalPanel()
        {
            okButton = new Button();
            okButton.Width = 100;
            okButton.Height = 32;
            okButton.Left = (this.Width - okButton.Width) / 2;
            okButton.Top = (this.Height - okButton.Height) / 2;
            okButton.Text = "OK";
            okButton.Click += delegate { this.Hide(); };
        }
        public virtual void ShowModal(Task completion)
        {
            this.task = completion;
            this.Dock = DockStyle.Fill;
            this.Show();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            var isHidden = !this.Visible;
            if (isHidden && task != null)
                task.Start();
        }
    }
