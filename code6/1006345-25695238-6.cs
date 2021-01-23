        public void SetBitmapImage()
        {
            System.Drawing.Bitmap bmp = TextToBitmap(*whatever goes here);
            *Element.Source = BitmapToBitmapImage(bmp);
        }
