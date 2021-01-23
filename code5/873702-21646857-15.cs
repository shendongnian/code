    void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
    {
            foreach (var result in e.Results)
            {
                var stream = result.GetPicture();
                if (stream != null)
                {
                    System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                    bmp.SetSource(stream); // You can do a list of image if you want to.
                    Image img = new Image();
                    img.Source = bmp;
                    stack.Children.Add(img); // I choose to display in a stackpanel
                }
            }
    }
