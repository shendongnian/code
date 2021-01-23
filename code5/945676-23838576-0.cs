    private void button1_MouseClick(object sender, MouseEventArgs e)
    {
        Formular2 Form2 = new Formular2();
        Form2.ShowDialog();
        if (Form2.DialogResult == DialogResult.Yes)
        {
            Form2.DialogResult = DialogResult.None;
        }
        else if (Form2.DialogResult == DialogResult.No)
        {
            Form2.DialogResult = DialogResult.None;
        }
        Form2.Show(); // or Form2.ShowDialog()
    }
