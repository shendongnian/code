    public class Form1 : Form
    {
        private Form2 mForm2 { get; set; }
    
        public void button1_Click(object sender, EventArgs e)
        {
            string departmentName = "IT";
            if (mForm2 == null)
                mForm2 = new Form2();
            mForm2.MyProperty = departmentName;
            frm2.Show();
            this.Hide();
        }
    
    }
