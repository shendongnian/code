    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormLoad);
            this.Resize += new System.EventHandler(this.FormResize);
        }
        protected virtual void FormLoad(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        protected virtual void FormResize(object sender, EventArgs e)
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
        ...
    }
    public class DerivedForm : BaseForm
    {
        protected override void FormLoad(object sender, EventArgs e)
        {
            base.FormLoad(sender, e);
            // specific code goes here
        }
        protected override void FormResize(object sender, EventArgs e)
        {
            base.FormResize(sender, e);
            // specific code goes here
        }
        ...
    }
