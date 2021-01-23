    namespace Auto
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Auto auto = new Auto();
                string returnedString = auto.SendToOtherApp(); // the string filled at the modal form text boxed will be returned to this variable
            }
    
        }
