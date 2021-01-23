			using (var source = (Bitmap) Image.FromFile(@"image filename"))
			{
				using (var target = new Bitmap(source.Width, source.Height))
				{
					using (var graphics = Graphics.FromImage(target))
					{
						using (var path = new GraphicsPath())
						{
							path.StartFigure();
							path.AddLine(161, 665, 223, 624);
							path.AddLine(223, 624, 252, 568);
							path.AddLine(252, 568, 239, 525);
							path.AddLine(239, 525, 200, 432);
							path.AddLine(200, 432, 178, 343);
							path.AddLine(178, 343, 156, 198);
							path.AddLine(156, 198, 161, 131);
							path.AddLine(161, 131, 248, 38);
							path.AddLine(248, 38, 366, 4);
							path.AddLine(366, 4, 657, 10);
							path.AddLine(657, 10, 735, 70);
							path.AddLine(735, 70, 741, 195);
							path.AddLine(741, 195, 746, 282);
							path.AddLine(746, 282, 762, 410);
							path.AddLine(762, 410, 730, 498);
							path.AddLine(730, 498, 686, 582);
							path.AddLine(686, 582, 727, 669);
							path.CloseFigure();
							graphics.Clip = new Region(path);
						}
						graphics.DrawImage(source, 0, 0);
					}
					this.PictureBox.Image = new Bitmap(target);
				}
			}
