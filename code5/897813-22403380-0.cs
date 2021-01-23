    public partial class Form1 : Form
    {
        ...
        private ShowPrintDialog()
        {
            using (var pd = new PrintDialog())
            {
                BeginInvoke(new MethodInvoker(TweakPrintDialog));
                if (pd.ShowDialog(this) == DialogResult.OK)
                {
                    // printing
                }
            }
        }
        private void TweakPrintDialog()
        {
            var printDialogHandle = GetActiveWindow();
            // do your tweaking here
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetActiveWindow();
    }
