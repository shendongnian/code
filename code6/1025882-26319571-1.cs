    public class Game 
    {
        Player hero = new Player("Tristan");
    
        private void NewGameClick(object sender, RoutedEventArgs e)
        {       
            MessageBox.Show("The character " + hero.Name + " has been created.");
        }
    }
