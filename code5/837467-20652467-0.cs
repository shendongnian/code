        private void Image_MouseUp1(object sender, MouseButtonEventArgs e)
        {
            var border = sender as Border;
            if (border != null)
            {
                var img = border.Child as Image;
                if (img != null)
                {
                    // your code
                }
            }
        }
