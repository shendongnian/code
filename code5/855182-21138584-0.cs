    private void button1_Click(object sender, EventArgs e)
    {
        DialogResult dialogResult  = MessageBox.Show("Är det roligt att programera", "Övning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult == DialogResult.No)
        {
            MessageBox.Show("Du suger", "ÅSNA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else if (dialogResult == DialogResult.Yes)
        {
            MessageBox.Show("Klart du gör", "Duktig", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
