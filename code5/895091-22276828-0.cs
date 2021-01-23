    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
           
            public void UpdateMainForm(string updatedString)
            {
                //here you can update  and invoke methods 
               
                
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                using (Form2 form2 = new Form2(this))
                {
                    form2.ShowDialog();
    
                }
            }
    
        }
