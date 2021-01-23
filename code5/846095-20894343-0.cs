    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        Utility tool1;
        public Form1()
        {
            InitializeComponent();
            tool1 =  new Utility();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tool1.StoreActiveUser(Int32.Parse(textBox1.Text), textBox2.Text);
            MessageBox.Show(String.Format("the values are :{0}  {1}", tool1.ActiveUserID.ToString(), tool1._ActiveUserName));
        }
        private void button2_Click(object sender, EventArgs e)
        {          
            MessageBox.Show(String.Format("the values are :{0}  {1}", tool1.ActiveUserID.ToString(), tool1._ActiveUserName));
            MessageBox.Show(String.Format(tool1.GetActiveUser().ToString()));
        }
    }
    }
