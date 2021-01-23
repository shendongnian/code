    public class NewClass
    {
        public void minimizeAll(System.Windows.Forms.Form yourForm)
        {
           foreach (Form childForm in yourParentForm.MdiChildren)
           {
              childForm.WindowState = FormWindowState.Minimized;
           }
        }
    }
