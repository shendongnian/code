    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(listBox1.SelectedIndex != -1)
        {
            btnVoirFiche.Enabled = true;
            btnEchangerJoueur.Enabled = true;
        }
        else
        {
           //whatever you need to test for
        }
    }
