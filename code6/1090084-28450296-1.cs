        private void lvNom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvNom.SelectedItem != null)
            {
                Person personneSelect = (Person)lvNom.SelectedItem;
                lvNom.SelectedItem = null;
                Frame.Navigate(typeof(DetailPersonne), personneSelect);
            }      
        }
