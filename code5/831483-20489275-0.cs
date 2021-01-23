    public Form2()
    {
         Form1 fm = new Form1();
         Form1.pFormname = this.Text; // this = Form2, Text = the arbitrary name of the form.
         fm.Show();
    }
