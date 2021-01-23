    private void button4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "*.*";
            ofd.Filter = "Media(*.*)|*.*";
            ofd.ShowDialog();
            mediaElement1.MediaOpened += new RoutedEventHandler(mediaElement1_MediaOpened);
            mediaElement1.Source = new Uri(ofd.FileName);
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            mediaElement1.Play();
        }
        
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Stop();
        }
 
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement1.Pause();
            
        }
