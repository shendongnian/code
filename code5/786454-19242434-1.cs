    namespace WindowsFormsApplication
    {
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            private Form2 form2;
    
            public Form1()
            {
                InitializeComponent();
    
                form2 = new Form2();
                form2.MyEventHandler += Form2EventHandler;
                
            }
    
            public void Form2EventHandler(object sender, MyEventArgs args)
            {
                MessageBox.Show(string.Format("Recieved value: {0}", args.Value));
            }
    
            private void button1_Click(object sender, System.EventArgs e)
            {
                form2.ShowDialog();
            }
        }
    }
