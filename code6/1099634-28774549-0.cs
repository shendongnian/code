    public sealed class SplashForm<T> : Form
        where T : Form
    {
        public SplashForm()
        {
            SuspendLayout();
            Size = new Size(350, 100);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            var lblMessage = new Label
            {
                Location = new Point(10, 10),
                Text = "loading..."
            };
            Controls.Add(lblMessage);
            ResumeLayout(false);
            PerformLayout();
            LoadMainForm();
        }
        private async void LoadMainForm()
        {
            Form instance = null;
            await Task.Run(() =>
            {
                //--get the main form type
                var firstFormType = GetType().GenericTypeArguments.First();
                //--create the instance
                instance = Activator.CreateInstance(firstFormType) as Form;
            });
            if (instance == null)
                throw new InvalidOperationException("form initialization error");
            OnMainFormLoaded(instance);
        }
        public event EventHandler<Form> MainFormLoaded;
        private void OnMainFormLoaded(Form formInstance)
        {
            EventHandler<Form> handler = MainFormLoaded;
            if (handler != null)
                handler(this, formInstance);
        }
    }
