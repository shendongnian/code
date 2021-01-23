    private void button1_Click(object sender, EventArgs e)
    {
        foreach (Form f in Application.OpenForms)
        {
            if (f is Form2)
            {
                //Form2 is activated. Close it
                f.Close();
            }
            if (f is Form3)
            {
                //Form3 is activated. Close it
                f.Close();
        }
    }
