    static class Module1
    {
        public static string strPath = System.Windows.Forms.Application.StartupPath + "\\";
        public static void LoadUserControl(System.Windows.Forms.UserControl obj, System.Windows.Forms.UserControl uc)
        {
            obj.Controls.Clear();
            uc.Left = (obj.Width - uc.Width) / 2;
            uc.Top = (obj.Height - uc.Height) / 2 - 10;
            obj.Controls.Add(uc);
        }
    }
