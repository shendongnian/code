                ListBox listBox = (sender as ListBox);
                if (listBox != null)
                {
                    imageProperty = (listBox.SelectedItem) as ImageProperty;
                    if (imageProperty != null)
                    {
                        string LstItem = imageProperty.ImageUrl;
                       
                        NavigationService.Navigate(new Uri("/View/ImageSelector.xaml?ImageUri=" + LstItem + "", UriKind.RelativeOrAbsolute));
                    }
                }
        }
