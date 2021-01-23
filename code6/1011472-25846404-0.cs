    public class RestorablePictureBox : PictureBox
		{
			private Image _restoreImage;
			private Image _restoreBackgroundImage;
			
			protected override void OnPaint(PaintEventArgs pe)
			{
				if (_restoreImage != null) _restoreImage.Dispose();
				if (_restoreBackgroundImage != null) _restoreBackgroundImage.Dispose();
				
				_restoreImage = this.Image;
				_restoreBackgroundImage = this.BackgroundImage;
				
				base.OnPaint(pe);
			}
			
			public void Restore(bool fill = false)
			{
				if (fill)
				{
					if (_restoreImage != null) _restoreImage.Dispose();
					if (_restoreBackgroundImage != null) _restoreBackgroundImage.Dispose();
					
					using (var gfx = this.CreateGraphics())
					{
						gfx.FillRectangle(Brushes.White, 0, 0, this.Width, this.Height); // Change Brushes.White to the color you want or use new SolidBrush(Color)
					}
				}
				else
				{
					if (_restoreImage != null) this.Image = _restoreImage;
					if (_restoreBackgroundImage != null) this.BackgroundImage = _restoreBackgroundImage;
				}
			}
		}
