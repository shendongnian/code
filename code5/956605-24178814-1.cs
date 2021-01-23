			using (LinearGradientBrush lgb = new LinearGradientBrush(rect, Color.Black, Color.White, 0f)) {
				float[] pos = new float[] { 0f, .125f, .25f, .375f, .5f, .625f, .75f, .875f, 1f };
				Blend b = new Blend();
				b.Positions = pos;
				b.Factors = new float[] { .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f, .125f };
				ColorBlend cb = new ColorBlend();
				cb.Positions = pos;
				cb.Colors = new Color[] {
					Color.FromArgb(0, 0, 0),
					Color.FromArgb(0, 0, 79),
					Color.FromArgb(81, 0, 123),
					Color.FromArgb(152, 0, 118),
					Color.FromArgb(211, 0, 62),
					Color.FromArgb(245, 31, 0),
					Color.FromArgb(255, 175, 0),
					Color.FromArgb(255, 255, 100),
					Color.FromArgb(255, 255, 255),
				};
				lgb.Blend = b;
				lgb.InterpolationColors = cb;
				e.Graphics.FillRectangle(lgb, rect);
			}
