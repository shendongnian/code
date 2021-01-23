            MouseButtonEventArgs m = e.EditingEventArgs as MouseButtonEventArgs;
            if (m != null)
            {
                double rowY = e.Row.TranslatePoint(new Point(0, e.Row.ActualHeight), this).Y;
                if (!(lstvwProductCode.RenderTransform is TransformGroup))
                    lstvwProductCode.RenderTransform = new TransformGroup();
                Point pos = m.GetPosition(this); //this = MainWindow
                pos.Y = rowY;
                Point tPoint = lstvwProductCode.TranslatePoint(new Point(0,0), this);
                ((TransformGroup)lstvwProductCode.RenderTransform).Children.Add(new TranslateTransform(pos.X - tPoint.X,pos.Y-tPoint.Y));
            }
