    Form2 f2 = null;
    private void button1_Click(object sender, EventArgs e)
    {
       f2 = new Form2(); 
       f2.Show();
    }
    private void Form1_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            f2.WindowState = FormWindowState.Minimized;
        }
    }
