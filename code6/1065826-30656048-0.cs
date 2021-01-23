    private void SelectMovie_Click(object sender, RoutedEventArgs e)
    {
       String buttonId = sender as String;
       // _moviePanelVM is an instance of my ViewModel
       _moviePanelVM.GetSelectedMovieDetails();
    }
 
