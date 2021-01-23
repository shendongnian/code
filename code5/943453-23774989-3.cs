    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.StatusChanged += form2_StatusChanged;
        }
    
        void form2_StatusChanged(object sender, Form2.StatusChangedArgs e)
        {
            // Update Form1's status bar here
        }
    }
