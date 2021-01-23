        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;
    using Nokia.Music.Types;
    
    namespace MusicApp
    {
        public partial class GenrePage : PhoneApplicationPage
        {
            public GenrePage()
            {
                InitializeComponent();
    
    
            }
    
            private async void GetGenres()
            {
                var genres = await App.GetClient().GetGenresAsync();
    
                
                GenresListBox.ItemsSource = genres;
                
                if (genres.Result == null || genres.Count == 0)
                {
                    MessageBox.Show("No results available");
                }
    
            }
    
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
    
                GetGenres();
            }
    
            private void SelectButton_Click(object sender, RoutedEventArgs e)
            {
                var genres = GenresListBox.SelectedItems;
                
            }
        }
    }
