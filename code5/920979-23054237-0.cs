    public class FormBase : Form
    {
        public FormBase()
        {
            this.WindowState = FormWindowState.Maximized;
            // put more generic code here
        }
        ... // or here
    }
    public class YourMdiChild : FormBase
    {
        ... // all code specific for that child
    }
