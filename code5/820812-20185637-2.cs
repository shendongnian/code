    public void btnIntroducir_Click(object sender, EventArgs e)
    {
        try
        {
            string n = txtNombre.Text;
            int s = int32.Parse(labScore2.Text);
            ScoreChanged(labScore2.Text); // This will reflect back to FMain labScore.Text
            lista[indice] = new Koby(n, s);
            indice++;
            muestraLista(ref lstJugadores);
            txtNombre.Clear();
            txtNombre.Enabled = false;
        }
     }
