    namespace WinClose
    {
        public partial class Form1 : Form
        {     
            //no need of CloseForm
        }
    }
    
    
    namespace WinClose
    {
        public partial class Form2 : Form
        {       
            private void button1_Click(object sender, EventArgs e)
            {
    			//Form1 o = new Form();//instance needed
                Form1 o= Application.OpenForms.OfType<Form1>		
                if(o != null)
                {    
                  o.Close();       
                }     
            }
        }
    }
