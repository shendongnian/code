        public void SetBitmapImage()
        {
            System.Drawing.Bitmap bmp = TextToBitmap(*whatever goes here);
            *Element.Background = new ImageBrush(BitmapToBitmapImage(bmp));
        }
