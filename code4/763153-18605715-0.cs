    public partial class Form1 : Form
    {        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2.VariableLable1 = "a";
            Form2.VariableLable2 = "b";
        }
    }
    
    public partial class Form2 : Form
    {  
        public static string VariableLable1,VariableLable2;
        private void form_load(object sender, EventArgs e)
        {
            Lable1.Text = VariableLable1;
            Lable1.Text = VariableLable2;
        }
    }
