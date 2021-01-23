        PathGeometry geo1;
        GeometrySink sink1;
   
            FactoryD2D factory = new FactoryD2D();
            var dpi = factory.DesktopDpi;
            RenderTarget renderTarget;
            renderTarget = new RenderTarget(factory, backBuffer, new RenderTargetProperties()
            {
                DpiX = dpi.Width,
                DpiY = dpi.Height,
                MinLevel = SharpDX.Direct2D1.FeatureLevel.Level_DEFAULT,
                PixelFormat = new SharpDX.Direct2D1.PixelFormat(Format.Unknown, AlphaMode.Ignore),
                Type = RenderTargetType.Hardware,
                Usage = RenderTargetUsage.None
            });
            // and after all initialization
                pta[0] = new SharpDX.Vector2(pts[4].X, pts[4].Y);
                pta[1] = new SharpDX.Vector2(pts[5].X, pts[5].Y);
                pta[2] = new SharpDX.Vector2(pts[6].X, pts[6].Y);
                pta[3] = new SharpDX.Vector2(pts[7].X, pts[7].Y);
                geo1 = new PathGeometry(factory);
                sink1 = geo1.Open();
                sink1.BeginFigure(pta[0], new FigureBegin());
                sink1.AddLines(new SharpDX.Vector2[] { pta[1], pta[2], pta[3] });
                sink1.EndFigure(new FigureEnd());
                sink1.Close();
                
            Color penColor = Color.Black;
            SolidColorBrush penBrush = new SolidColorBrush(g, new SharpDX.Color(penColor.R, penColor.G, penColor.B));
            Color color = AddColor(pt, zmin, zmax);
            SolidColorBrush aBrush = new SolidColorBrush(g, new SharpDX.Color(color.R, color.G, color.B));
                
                renderTarget.DrawGeometry(geo1, penBrush);
                renderTarget.FillGeometry(geo1, aBrush);
                geo1.Dispose();
                sink1.Dispose();
