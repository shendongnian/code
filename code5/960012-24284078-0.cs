    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            private List<string> myList = null;
            public Form1()
            {
                InitializeComponent();
                myList = new List<string>();
                myList.Add("Dave");
                myList.Add("Sam");
                myList.Add("Gareth");
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (string item in myList)
                {
                   listView1.Items.Add(item);
                }
            }
        }
    }
