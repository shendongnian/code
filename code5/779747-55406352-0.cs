        /// <summary>Redimensiona y recorta la imagen en forma de Circulo (con Antialias).</summary>
		/// <param name="srcImage">Imagen Original a Recortar</param>
		/// <param name="size">Tamaño deseado (en pixeles)</param>
		/// <param name="BackColor">Color de fondo</param>
		public static Image CropToCircle(System.Drawing.Image srcImage, Size size, System.Drawing.Color BackColor)
		{
			System.Drawing.Image Canvas = new System.Drawing.Bitmap(size.Width, size.Height, srcImage.PixelFormat);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(Canvas);
			System.Drawing.Rectangle outerRect = new System.Drawing.Rectangle(-1, -1, Canvas.Width + 1, Canvas.Height + 1);
			System.Drawing.Rectangle rect = System.Drawing.Rectangle.Inflate(outerRect, -2, -2);
			g.DrawImage(srcImage, outerRect);
			using (System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(BackColor))
			using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				path.AddEllipse(rect);
				path.AddRectangle(outerRect);
				g.FillPath(brush, path);
			}
			return Canvas;
		}
