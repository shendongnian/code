    private void lstJoueurs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstJoueurs.SelectedIndex != -1)
        {
            btnVoirFiche.Enabled = true;
            btnEchangerJoueur.Enabled = true;
        }
     }
