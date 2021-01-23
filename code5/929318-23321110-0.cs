        public void updateWithSprite(int x, int y, Sprite sprite)
        {
            
            Bitmap sprBitmap = sprite.getBitmap();
            Graphics g = Graphics.FromImage(this.bitmap);
            g.DrawImage(sprBitmap, x, y, sprBitmap.Width, sprBitmap.Height);
            g.Dispose();
        }
