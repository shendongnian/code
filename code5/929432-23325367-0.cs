    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
                Loaded += MainWindow_Loaded;
            }
    
            private void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                // Let's pretend this is your HtmlNodeCollection 
                var collection = new List<Song>
                {
                    new Song
                    {
                        Artist = "Joeski & Chus",
                        Title = "El Amor",
                        Duration = TimeSpan.FromMinutes(5).TotalSeconds
                    },
                    new Song
                    {
                        Artist = "Dano & Joeski",
                        Title = "For your love",
                        Duration = TimeSpan.FromMinutes(10).TotalSeconds
                    },
                };
    
                // Build objects from your HTML nodes ...
                var songs = new ObservableCollection<Song>();
                foreach (Song song in collection)
                {
                    songs.Add(song);
                }
    
                DataContext = songs;
            }
        }
    
        internal class Song
        {
            public string Artist { get; set; }
            public string Title { get; set; }
            public double Duration { get; set; }
        }
    }
