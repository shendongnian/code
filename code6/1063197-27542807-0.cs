        public void DoSomething(string s)
        {
            var form = System.Windows.Forms.Application.OpenForms[0];
            if (form.InvokeRequired)
            {
                Action<string> m = DoSomething;
                form.Invoke(m, s);
                return;
            }
            //do something
        }
