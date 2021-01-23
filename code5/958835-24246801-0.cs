    public class Form1 : Form
    {
        // other stuff
        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 == null)
                f2 = new Form2(this);
            f2.Show();
        }
    }
    public class Form2 : Form
    {
        private Form1 Form1Reference { get; set; }
        // other stuff
        public Form2(Form1 form1Reference)
        {
            Form1Reference = form1Reference;
        }
    }
