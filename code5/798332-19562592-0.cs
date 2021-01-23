    public delegate void MenuClickEventHandler(object sender, RoutedEventArgs e);
            public event MenuClickEventHandler MenuClicked;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (MenuClicked != null)
                {
                    MenuClicked(this, e);
                }
            }
