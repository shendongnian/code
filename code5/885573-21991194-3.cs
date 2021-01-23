    internal class GuiCursor
    {
        private static GuiCursor instance = new GuiCursor();
        private GuiCursor() { }
        static GuiCursor() { }
        internal static void WaitCursor(MethodInvoker oper)
        {
            if (Form.ActiveForm != null && !Thread.CurrentThread.IsBackground)
            {
                Form myform = Form.ActiveForm;
                myform.Cursor = Cursors.WaitCursor;
                try
                {
                    oper();
                }
                finally
                {
                    myform.Cursor = Cursors.Default;
                }
            }
            else
            {
                oper();
            }
        }
        internal static void ToggleWaitCursor(Form form, bool wait)
        {
            if (form != null)
            {
                if (form.InvokeRequired)
                {
                    form.Invoke(new MethodInvoker(() => { form.Cursor = wait? Cursors.WaitCursor : Cursors.Default; }));
                }
                else
                {
                    form.Cursor = wait ? Cursors.WaitCursor : Cursors.Default;
                }
            }
        }
        internal static void Run(Form form)
        {
            try
            {
                Application.Run(form);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
