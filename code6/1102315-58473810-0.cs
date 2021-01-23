        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            Android.Graphics.LinearGradient gradient;
            using (var path = new Android.Graphics.Path())
            using(var paint = new Android.Graphics.Paint()
                {
                    Dither = true,
                    AntiAlias = true,
                })
            using (Android.Graphics.Path.Direction direction = Android.Graphics.Path.Direction.Cw)
            using (var rect = new Android.Graphics.RectF(0, 0, (float)canvas.Width, (float)canvas.Height))
            {
                if (Element.Orientation == StackOrientation.Vertical)
                    gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height, this.StartColor.ToAndroid(),
                       this.EndColor.ToAndroid(),
                       Android.Graphics.Shader.TileMode.Mirror);
                else
                    gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0, this.StartColor.ToAndroid(),
                       this.EndColor.ToAndroid(),
                       Android.Graphics.Shader.TileMode.Mirror);
                path.AddRect(rect, direction);
                paint.SetShader(gradient);
                canvas.DrawPath(path, paint);
            }
            base.DispatchDraw(canvas);
        }
