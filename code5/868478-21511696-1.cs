    namespace TEST_CSA
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
    
            private Form1 _parent;
            internal void RegisterParent(Form1 form)
            {
                this._parent = form;
            }
    
            private void Form2_FormClosing(object sender, FormClosingEventArgs e)
            {
                _parent.Enabled = true;
            }
    
        }
    }
