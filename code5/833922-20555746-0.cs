    public decimal Trekking(int Maxwaarde, int AantalGewenst) {
      decimal result = ERROR;
      if (Maxwaarde > 90) {
        MessageBox.Show("Uw getal mag niet boven de 90 zijn!");
        return result;
      } else if (Maxwaarde < 0) {
        MessageBox.Show("Dit aantal is niet mogelijk!");
        return result;
      } else if (AantalGewenst > 45) {
        MessageBox.Show("Uw getal mag niet boven de 45 zijn!");
        return result;
      } else if (AantalGewenst < 0) {
        MessageBox.Show("Dit aantal is niet mogelijk!");
        return result;
      } else if (Maxwaarde / AantalGewenst < 2) {
        MessageBox.Show("Uw maxwaarde moet minstens het dubbele van Aantal Gewenst zijn!");
        return result;
      } else {
        if (AantalGewenst <= 45)
          IsTenEinde = true;
      }
      var random = new Random();
      var getallen = new int[AantalGewenst];
      this.Maxwaarde = Maxwaarde;
      this.AantalGewenst = AantalGewenst;
      result = (decimal)Maxwaarde / (decimal)AantalGewenst;
      AantalGetrokken = 0;
      IsTenEinde = false;
      return result;
    }
