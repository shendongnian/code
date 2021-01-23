    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   
        public void ClearAllTextboxes() 
        {
            ForeachTextbox(this, x => x.Text = "");
        }
        public static void ForeachTextbox(Control parent, Action<TextBox> action)
        {
            if (parent is TextBox)
            {
                action((TextBox)parent);
            }
            foreach (Control cntrl in parent.Controls)
            {
                ForeachTextbox(cntrl, action);
            }
        }
    }
