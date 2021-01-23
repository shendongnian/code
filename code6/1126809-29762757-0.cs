    public void DrawFaceModel(DrawingContext drawingContext)
            {
                if (!this.lastFaceTrackSucceeded || this.skeletonTrackingState != SkeletonTrackingState.Tracked)
                {
                    return;
                }
                var faceModelPts = new List<Point>();
                var faceModel = new List<FaceModelTriangle>();
                //double[] xarray;
                //double[] yarray;
                for (int i = 0; i < this.facePoints.Count; i++)
                {
                    faceModelPts.Add(new Point(this.facePoints[i].X + 0.5f, this.facePoints[i].Y + 0.5f));
                    //xarray[i] = this.facePoints[i].X;
                    //yarray[i] = this.facePoints[i].Y;
                }
               // double xpos21 = this.facePoints[21].X;
                //double xpos21 = this.facePoints[21].X;
                //Bikin Titik di jidat
               
                foreach (var t in faceTriangles)
                {
                    var triangle = new FaceModelTriangle();
                    triangle.P1 = faceModelPts[t.First];
                    triangle.P2 = faceModelPts[t.Second];
                    triangle.P3 = faceModelPts[t.Third];
                    faceModel.Add(triangle);
                }
                
               // ColorImagePoint j1p = faceModelPts.Add(new Point(this.facePoints[1].X + 0.5f, this.facePoints[1].Y + 0.5f));
               // ColorImagePoint j1p = myKinect.MapSkeletonPointToColor(faceModelPts[1].Position, ColorImageFormat.RgbResolution640x480Fps30);
                               
                //var faceModelGroup = new GeometryGroup();
                //for (int i = 0; i < faceModel.Count; i++)
                //{
                //    var faceTriangle = new GeometryGroup();
                //    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P1, faceModel[i].P2));
                //    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P2, faceModel[i].P3));
                //    faceTriangle.Children.Add(new LineGeometry(faceModel[i].P3, faceModel[i].P1));
                //    faceModelGroup.Children.Add(faceTriangle);
                //}
                var faceModelGroup = new GeometryGroup();
                //for (int i = 0; i < faceModel.Count; i++)
                //{
                    var faceTriangle = new GeometryGroup();
                    faceTriangle.Children.Add(new LineGeometry(faceModel[1].P1, faceModel[1].P2));
                    faceTriangle.Children.Add(new LineGeometry(faceModel[1].P2, faceModel[1].P3));
                    faceTriangle.Children.Add(new LineGeometry(faceModel[1].P3, faceModel[1].P1));
                    faceModelGroup.Children.Add(faceTriangle);
                //}
                    //((MainWindow)System.Windows.Application.Current.MainWindow).jidat1.Content = Math.Round(facePoints[1].X,3);
                    //((MainWindow)System.Windows.Application.Current.MainWindow).jidat2.Content = Math.Round(facePoints[1].Y,3);
               drawingContext.DrawGeometry(Brushes.LightYellow, new Pen(Brushes.LightYellow, 1.0), faceModelGroup);
               //drawingContext.DrawEllipse(Brushes.LightYellow, new Pen(Brushes.LightYellow, 1.0), faceModelPts[1]);
             }
