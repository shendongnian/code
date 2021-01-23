       public async void GetPixel(Image pictureBox)
        {
            WriteableBitmap modifiedImage = pictureBox.Source as WriteableBitmap;
            if (modifiedImage == null)
            {
                BitmapSource bs = pictureBox.Source as BitmapSource;
                modifiedImage = new WriteableBitmap(bs);
                
            }
                    Color pixelColor = modifiedImage.GetPixel(300,300);
                    string myString = pixelColor.ToString();
                    TextBlock1.Text = myString;
        }
