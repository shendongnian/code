    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult rezult = MessageBox.Show("Sunteti sigur ca doriti sa iesiti din program !?",
            "Aplication closing", MessageBoxButtons.YesNoCancel);
        if (rezult == DialogResult.Yes)
        {
            // call other event handler as a function, for it is one
            saveAsToolStripMenuItem_Click(null, null);
            e.Cancel = false;
        }
        else if (rezult == DialogResult.No)
        {
            e.Cancel = false;
        }
        else
            e.Cancel = true;
    }
