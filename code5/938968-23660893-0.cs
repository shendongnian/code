    class Peça : DrawingArea
    {
        private Point _Offset = Point.Empty;
        public Boolean movable = false;
        public Image imagem
        {
            get;
            set;
        }
        protected override void OnDraw()
        {
            Rectangle location = new Rectangle(0, 0, imagem.Width, imagem.Height);
            this.graphics.DrawImage(imagem, location);
        }
        public Boolean Down(Point e, bool propaga = true)
        {
            Bitmap b = new Bitmap(imagem);
            Color? color = null;
            Boolean flag = false;
            try
            {
                color = b.GetPixel(e.X, e.Y);
                if (color.Value.A != 0 && color != null)
                {
                   flag = true;
                }
                else
                {
                    flag = false;
                }
                return flag;
            }
            catch
            {
                return flag;
            }
        }
    }
