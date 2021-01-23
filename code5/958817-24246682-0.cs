    public class frmMain
    {
        private static frmMain Instance = null;
        private static object LockObj = new object();
        public static frmMain GetMain()
        {
            // Thread-safe singleton
            lock(LockObj)
            {
                if(Instance == null)
                    Instance = new frmMain();
                return Instance;
            }
        }
        public string GetOptionsDisplayText()
        {
            return txtOptionsDisplay.Text;
        }
    }
    public class frmSelect
    {
        private void frmSelect_Load(object sender, EventArgs e)
        {
            // Set whatever text you want to frmMain's txtOptionsDisplay text
            txtDisplay.Text = frmMain.GetMain().GetOptionsDisplayText();
        }
    }
