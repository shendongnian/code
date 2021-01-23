    public partial class MainWindow : Window
    {
        Vijftig spel = new Vijftig();  
  
    private void btnSpelen_Click(object sender, RoutedEventArgs e)
        {
            spel.Speel();
            ToonStenen();
           
            Button clickedButton = sender as Button;
            if ((string)clickedButton.Content == "Gooien speler 1")
            {
                clickedButton.Content = "Gooien speler 2";
                spel.score1 = spel.BerekenScore(spel.score1);
                lblScoreSpeler1.Content = spel.score1.ToString();
            }
            else if ((string)clickedButton.Content == "Gooien speler 2")
            {
                clickedButton.Content = "Gooien speler 1";
                spel.score2 = spel.BerekenScore(spel.score2);
                lblScoreSpeler2.Content = spel.score2.ToString();
            }
    public void ToonStenen()
        {
            imgDobbelsteen1.Source = new BitmapImage(new Uri("Resources/" + spel.steen1.aantalOgen + ".jpg", UriKind.Relative));
            imgDobbelsteen2.Source = new BitmapImage(new Uri("Resources/" + spel.steen2.aantalOgen + ".jpg", UriKind.Relative));
        }
    }
