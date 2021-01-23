    private void Canvas_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
            {
                currentPoint = e.GetPosition(this.canvas);
                //Initialize line according to currentpoint position.
                Line line = new Line() { X1 = currentPoint.X, Y1 = currentPoint.Y, X2 = oldPoint.X, Y2 = oldPoint.Y };
               
                    line.StrokeDashCap = PenLineCap.Round;
                    line.StrokeEndLineCap = PenLineCap.Round;
                    line.StrokeLineJoin = PenLineJoin.Round;
                    line.StrokeThickness = 10;
                    line.Stroke = new SolidColorBrush(Colors.White) ;
                ////////////////////////////////
                //Set color & thickness of line. 
                
                //Line add in canvas children to draw image & assign oldpoint.
                this.canvas.Children.Add(line);
                oldPoint = currentPoint;
            }
