    protected void btnGoo_Click(object sender, EventArgs e)
        {
    
            this.txtErgebnis.BackColor = System.Drawing.Color.White;
            this.txtErgebnis.Text = "";
            this.txtErgebnis.ForeColor = System.Drawing.Color.White;
            //variablen Definieren
            double dblGroesse = 0;
            double dblGewicht = 0;
            double dblErgebnis = 0;
    
            if (Double.TryParse(txtGroesse.Text, out dblGroesse) == false) {
                txtGroesse.Text = "Geben Sie ihre Grösse ein";
                return;
            }
    
            if (Double.TryParse(txtGewicht.Text, out dblGewicht) == false)
            {
                txtGewicht.Text = "Geben Sie ihr Gewicht ein";
                return;
            }
    
    
            dblErgebnis = dblGewicht / (dblGroesse * dblGroesse);
            txtErgebnis.Text = Convert.ToString (dblErgebnis);
    
                if (dblErgebnis <= 16)
                {
                this.txtErgebnis.BackColor = System.Drawing.Color.Coral;
                this.txtErgebnis.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            }
    
            else if (dblErgebnis <= 25)
            {
                this.txtErgebnis.BackColor = System.Drawing.Color.DarkRed;
                this.txtErgebnis.ForeColor = System.Drawing.Color.DarkSlateGray;
            }
    }
    }
