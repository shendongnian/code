		void RefreshScreen()
		{
				using (Surface s = sc.CaptureScreen())
				{
					using (DataStream ds = Surface.ToStream(s, ImageFileFormat.Bmp))
					{
						Image oldBgImage = panelMain.BackgroundImage;
						panelMain.BackgroundImage = Image.FromStream(ds);
						if (oldBgImage != null)
							oldBgImage.Dispose();
					}
				}
		}
