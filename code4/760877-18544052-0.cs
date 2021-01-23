    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form2 frm2 = new Form2();
            frm2.MdiParent = this;
            frm2.Show();
        }
        protected override void OnResize(EventArgs e)
        {
            CenterForms();
            base.OnResize(e);
        }
        private void CenterForms()
        {
            foreach (var form in MdiChildren) //This will center all of the Child Forms
            {
                form.Left = (ClientRectangle.Width - form.Width) / 2;
                form.Top = (ClientRectangle.Height - form.Height) / 2;
            }
            
        }
    }
