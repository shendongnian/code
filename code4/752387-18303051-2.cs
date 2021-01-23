    using System.Windows.Forms;
    public static class Extensions
    {
        public static void OpenForm<T>(this T frm, Form parent) where T : Form, new()
        {
            if (frm != null && FormOpen(frm.Text))
                frm.Activate();
            else
            {
                frm = new T();
                frm.MdiParent = parent;
                frm.FormClosed += (sender, args) => {frm.Dispose(); frm = null;};
                frm.Show();
            }
        }
        private static bool FormOpen(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                    return true;
            }
            return false;
        }
    }
