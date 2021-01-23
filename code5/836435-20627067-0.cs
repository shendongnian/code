    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private  int flag;
            public Form1()
            {
                InitializeComponent();
            }
            private void SetFlag()
            {
                FileInfo info = new FileInfo("c:\\test.txt");
                    if (info.Length > 0)  
                        flag= 1;
            }
            private void CheckFlag()
            {
                if(flag==1)
                {
                    button1.PerformClick();
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //Code for Redirection to New Form
            }            
        }
    }
