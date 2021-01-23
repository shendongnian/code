            MouseButtonEventArgs m = e.EditingEventArgs as MouseButtonEventArgs;
            if (m != null)
            {
                if (!(lstvwProductCode.RenderTransform is TransformGroup))
                    lstvwProductCode.RenderTransform = new TransformGroup();
                Point pos = m.GetPosition(this); //this = MainWindow
                Point tPoint = lstvwProductCode.TranslatePoint(new Point(0,0), this);
                ((TransformGroup)lstvwProductCode.RenderTransform).Children.Add(new TranslateTransform(pos.X - tPoint.X,pos.Y-tPoint.Y));
            }
