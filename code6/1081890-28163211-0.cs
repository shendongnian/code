        private void CaptureScreen()
        {
            memoryImage = new Bitmap(this.Size.Width, this.Size.Height);
            this.DrawToBitmap(memoryImage, new Rectangle(new Point(0, 0), this.Size));
        }
