	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Image image = new Bitmap("HouseAndTree.gif");
			TextureBrush tBrush = new TextureBrush(image);
			Pen blackPen = new Pen(Color.Black);
			tBrush.WrapMode = WrapMode.TileFlipXY;
			var clientHalfWidth = ClientSize.Width / 2.0;
			var clientHalfHeight = ClientSize.Height / 2.0;
			var offsetX = clientHalfWidth - (Math.Floor(clientHalfWidth / image.Width + 0.5) + 0.5) * image.Width;
			var offsetY = clientHalfHeight - (Math.Floor(clientHalfHeight / image.Height + 0.5) + 0.5) * image.Height;
			var g = e.Graphics;
			var offsetRect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, (int)(ClientSize.Width - offsetX), (int)(ClientSize.Height - offsetY));
			g.DrawRectangle(blackPen, ClientRectangle);
			g.TranslateTransform((float)offsetX, (float)offsetY);
			g.FillRectangle(tBrush, offsetRect);
			// Draw the reference lines if you need to.
			g.ResetTransform();
			g.TranslateTransform(ClientRectangle.Left, ClientRectangle.Top);
			g.DrawLine(blackPen, (int)clientHalfWidth, 0, (int)clientHalfWidth, ClientSize.Height);
			g.DrawLine(blackPen, 0, (int)clientHalfHeight, ClientSize.Width, (int)clientHalfHeight);
		}
	}
