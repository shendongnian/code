    internal class FormRunner
    {
        internal Form1 form = new Form1();
        internal void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);
        }
        private delegate void StopDelegate();
        public void Stop()
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new StopDelegate(Stop));
                return;
            }
            form.Close();
        }
        private delegate void DisplayDelegate(string s);
        public void Display(string s)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(new DisplayDelegate(form.Display), new[] {s});
            }
        }
    }
