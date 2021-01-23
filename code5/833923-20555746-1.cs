    private void btnStart_Click(object sender, EventArgs e) {
      btnTrek.Enabled = false;
      btnStop.Enabled = false;
      int AantalGewenst = Convert.ToInt32(tbInvoerAantalGewenst.Text);
      int Maxwaarde = Convert.ToInt32(tbInvoerMaxwaarde.Text);
      decimal trekking = Trekking(Maxwaarde, AantalGewenst);
      btnTrek.Enabled = true;
      btnStop.Enabled = true;
      if (ERROR < trekking) {
        MessageBox.Show(trekking.ToString());
      }
    }
