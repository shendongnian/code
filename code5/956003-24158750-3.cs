    public partial class Form4 : Form
    {
        public Form4()
        {
           InitializeComponent();       
        }
        private void newButton_Click(object sender, EventArgs e)
        { 
             Form5 form5 = new Form5(this);
             form5.Show();
        }
        ...
     }
