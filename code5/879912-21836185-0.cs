    private void pinCanvas_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
            {
             //   Point pt = e.GetPosition(pinCanvas);
             //   Curosor.Text = String.Format("You are at ({0}in, {1}in) in window coordinates", (pt.X / (96 / 72)) * 1/72, (pt.Y / (96 / 72)) * 1/72);
            }
            bool captured = false;
            double x_shape, x_canvas, y_shape, y_canvas;
            UIElement source = null;
            string elementName;
            double elementHeight, elementWidth;
            private void pinCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                setCanvasSize();
                source = (UIElement)sender;
                elementName = ((Label)source).Name;
                switch (elementName)
                {
                    case "pinTextBox" :
                        elementHeight = pinActualHeight;
                        elementWidth = pinActualWidth;
                        break;
                    case "serialTextBox" :
                        elementHeight = serialActualHeight;
                        elementWidth = serialActualWidth;
                        break;
                    case "batchTextBox" :
                        elementHeight = batchActualHeight;
                        elementWidth = batchActualWidth;
                        break;
                }
                Mouse.Capture(source);
                captured = true;
                x_shape = Canvas.GetLeft(source);
                x_canvas = e.GetPosition(Maincanvas).X;
                y_shape = Canvas.GetTop(source);
                y_canvas = e.GetPosition(Maincanvas).Y;
            }
    
            private void pinCanvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (captured)
                {
    
                    double x = e.GetPosition(Maincanvas).X;
                    double y = e.GetPosition(Maincanvas).Y;
                    var xCond = Math.Round(appActivities.DIP2Inch(x_shape), 4).ToString();
                    var yCond = Math.Round(appActivities.DIP2Inch(y_shape), 4).ToString();
                    var name = ((Label)source).Name;
                    x_shape += x - x_canvas;
                //    if ((x_shape < Maincanvas.ActualWidth - elementWidth) && x_shape > 0)
               //     {
                        Canvas.SetLeft(source, x_shape);
                        switch (name)
                        {
                            case "pinTextBox" :
                                pinOffsetLeft.Text = xCond;
                                break;
                            case "serialTextBox" :
                                serialOffsetLeft.Text = xCond;
                                break;
                            case "batchTextBox" :
                                batchOffsetLeft.Text = xCond;
                                break;
                        }
                        
             //       }
                    x_canvas = x;
                    y_shape += y - y_canvas;
                //    if (y_shape < Maincanvas.ActualHeight - elementHeight && y_shape > 0)
                 //   {
                        Canvas.SetTop(source, y_shape);
                        switch (name)
                        {
                            case "pinTextBox":
                                pinOffsetTop.Text = yCond;
                                break;
                            case "serialTextBox":
                                serialOffsetTop.Text = yCond;
                                break;
                            case "batchTextBox":
                                batchOffsetTop.Text = yCond;
                                break;
                        }
    
              //      }
                    y_canvas = y;
                }
            }
    
            private void pinCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                Mouse.Capture(null);
                captured = false;
              //  MessageBox.Show((Canvas.GetTop(source)).ToString());
             /*   if (Canvas.GetTop(source) < 0)
                {
                    Canvas.SetTop(source, 0);
                }
                if (Canvas.GetLeft(source) < 0)
                {
                    Canvas.SetLeft(source, 0);
                }
    
                if (Canvas.GetLeft(source) > Maincanvas.ActualWidth - elementWidth)
                {
                  //  MessageBox.Show("Left Too Much " + (Canvas.GetLeft(source) * 1/96).ToString());
                    Canvas.SetLeft(source, Maincanvas.ActualWidth - elementWidth);
                }
    
                if (Canvas.GetTop(source) > Maincanvas.ActualHeight - elementHeight)
                {
                    Canvas.SetTop(source, Maincanvas.ActualHeight - elementHeight);
                } */
                oneElemntTorched = true;
                //MessageBox.Show(this.pinTextBox.ActualHeight.ToString() + ", " + this.pinTextBox.ActualWidth.ToString());
            }
