    private void tbSold_TextChanged(object sender, TextChangedEventArgs e)
    {
        tbSold.Text = tbSold.Text.Replace(',', '.');
        tbSold.Select(tbSold.Text.Length, 0);
        double BO; 
        bool boughtPrased = double.TryParse(tbBought.Text, out BO);
        // what should you do if the parse fails?
        double SO;
        bool soldParsed = double.Parse(tbSold.Text, out SO);
        // what should you do if the parse fails?
  
        double TOT = (SO / BO);  // convert to percentage in format below
        // what do you do if BO is 0?
        // display as percentage with two decimal digits
        tbTotal.Text = string.Format("{0:P2}",TOT);
    }
