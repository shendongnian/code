    public class D_Search
    {
        Form1 frm = null;
        public D_Search(Form1 frm1)
        {
            frm = frm1;
        }
        public string filterD(object sender)
        {
            string val = String.Empty;
            if (sender == frm.textBox1)
            {
                val = (sender as TextBox).Text;
            }
            return val;
        }
    }
