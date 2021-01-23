    public partial class Form2: Form
    {       
        public Form2()
        { 
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
             if(string.IsNullOrEmpty(Program.sCurrentUserName) == false)
               MessageBox.Show("Welcome " + Program.sCurrentUserName);
             else
             {
                 //do something
             }
        }
    }
