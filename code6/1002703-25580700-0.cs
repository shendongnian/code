        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRect == null)
                return;
            //Create a copy of rectangle
            string rectXaml = XamlWriter.Save(selectedRect);
            StringReader stringReader = new StringReader(rectXaml);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Rectangle newRect = (Rectangle)XamlReader.Load(xmlReader);
            double cX, cY, sX, sY;
            sX = 1;
            sY = 1;
            cX = newRect.Width / 2;
            cY = newRect.Height / 2;
            double top = Canvas.GetTop(selectedRect);
            double left = Canvas.GetLeft(selectedRect);
            switch ((sender as Button).Content.ToString())
            {
                case "Up":
                    sX = 1;
                    sY = -1;
                    top -= selectedRect.Height;
                    break;
                case "Down":
                    sX = 1;
                    sY = -1;
                    top += selectedRect.Height;
                    break;
                case "Left":
                    sX = -1;
                    sY = 1;
                    left -= selectedRect.Width;
                    break;
                case "Right":
                    sX = -1;
                    sY = 1;
                    left += selectedRect.Width;
                    break;
            }
            Canvas.SetLeft(newRect, left);
            Canvas.SetTop(newRect, top);
            newRect.Stroke = Brushes.Black;
            ScaleTransform trans = newRect.RenderTransform as ScaleTransform;
            if (trans != null)
            {
                //flip the previous transform
                trans.ScaleX *= sX;
                trans.ScaleY *= sY;
            }
            else
            {
                //create a new if none
                trans = new ScaleTransform(sX, sY, cX, cY);
            }
            newRect.RenderTransform = trans;
            newRect.MouseDown += new MouseButtonEventHandler(rect_MouseDown);
            //Add new rect to Canvas
            canvas.Children.Add(newRect);
            //optional to set the new rect as selected for continuous flip copy
            newRect.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left) { RoutedEvent = Rectangle.MouseDownEvent });
        }
