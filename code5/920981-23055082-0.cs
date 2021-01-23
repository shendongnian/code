    public class ChildForm : Form
    {
        public void doTheSizing()
        {
            // make it maximize...
            // your sizing of pannel...
            // etc...
        }
    }
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm childForm01 = new ChildForm();
            childForm01.doTheSizing();
            // now show the child window using Show() or ShowDialog().
            childForm01.ShowDialog();
        }
    }
