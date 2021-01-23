        public void changeLabelText(System.Windows.Forms.Label lib, String whateva)
        {
            if (lib.InvokeRequired)
            {
                lib.BeginInvoke(new MethodInvoker(() => changeLabelText(lib, whateva)));
            }
            else
            {
                lib.Text = whateva;
            }
        }
