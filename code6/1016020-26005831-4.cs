    private void FindRegions(int cx0, int cx1, int cy0, int cy1, int radius0, int radius1, ref Region rgnLeft, ref Region rgnRight)
        {
            //Left circle
            GraphicsPath gpL = new GraphicsPath();
            //Right circle
            GraphicsPath gpR = new GraphicsPath();
            //The right small region (yellow color)
            GraphicsPath gp = new GraphicsPath();
            //Points of intersection
            PointF pnt1 = new PointF();
            PointF pnt2 = new PointF();
            Graphics g = this.CreateGraphics();
            gpL.AddEllipse(new Rectangle(cx0 - radius0, cy0 - radius0, 2 * radius0, 2 * radius0));
            gpR.AddEllipse(new Rectangle(cx1 - radius0, cy1 - radius1, 2 * radius1, 2 * radius1));
            g.DrawPath(Pens.Red, gpL);
            g.DrawPath(Pens.Blue, gpR);
            int numPoints = FindCircleCircleIntersections((single)cx0, (single)cx1, (single)cy0, (single)cy1, (single)radius0, (single)radius1, ref pnt1, ref pnt2);
            if (numPoints != 2)
            {
                //No regions
                return;
            }
         
            Double theta, fe;
            Double dx = (double)pnt1.X - (double)pnt2.X;
            Double dy = (double)pnt1.Y - (double)pnt2.Y;
            Double dist = Math.Sqrt(dx * dx + dy * dy);
            PointF minPoint, maxPoint;
            if (pnt2.Y < pnt1.Y)
            {
                minPoint = pnt2;
                maxPoint = pnt1;
            }
            else
            {
                minPoint = pnt1;
                maxPoint = pnt2;
            }
            //theta is the angle between the three points pnt1, pnt2 and left center
            theta = Math.Acos((dist / 2D) / 100D);
            theta = (theta * 180D) / Math.PI;
            theta = 90D - theta;
            theta *= 2D;
            //fe is the starting angle of the point(between pnt1 and pnt2) with 
            //the smaller y coordinate. The angle is measured from x axis and clockwise
            fe = Math.Asin( Math .Abs ( (-(Double)minPoint.Y + (double)cy0) )/ (double)radius0);
            fe = (fe * 180D) / Math.PI;
            if (minPoint.X > cx0 && minPoint.Y >= cy0)
            {
                //fe = (90 - fe) + 270;
            }
            else if (minPoint.X > cx0 && minPoint.Y < cy0)
            {
                fe = (90D - fe) + 270D;
            }
            else if (minPoint.X == cx0 && minPoint.Y < cy0)
            {
                fe = 270D;
            }
            else
            {
                fe += 180D;
            }
            gp.AddArc(new Rectangle(cx0 - radius0, cy0 - radius0, 2 * radius0, 2 * radius0), (float)fe, (float)theta);
            gp.AddLine(maxPoint, minPoint);
            gp.CloseFigure();
            g.DrawPath(Pens.Green, gp);
            Region rgnL = new Region(gpL);
            Region rgnR = new Region(gpR);
            Region rgnInt = new Region(gpL);
            Region rgn = new Region(gp); //right small
            rgnInt.Intersect(rgnR);
            rgnInt.Exclude(rgn); //left small
            g.FillRegion(Brushes.DarkGreen, rgnInt);
            g.FillRegion(Brushes.DarkGray, rgn);
            rgnLeft = rgnInt.Clone();
            rgnRight = rgn.Clone();
            g.Dispose();
            rgnL.Dispose();
            rgnR.Dispose();
            rgnInt.Dispose();
            rgn.Dispose();
            gpL.Dispose();
            gpR.Dispose();
            gp.Dispose(); 
        }
        private int FindCircleCircleIntersections(Single cx0, Single cx1, Single cy0, Single cy1, Single radius0, Single radius1, 
                                                   ref PointF intersection1, ref PointF intersection2)
        {
            // Find the distance between the centers.
            Single dx = cx0 - cx1;
            Single dy = cy0 - cy1;
            Double dist = Math.Sqrt(dx * dx + dy * dy);
            // See how many solutions there are.
            if (dist > radius0 + radius1) 
            {
                //No solutions, the circles are too far apart.
                intersection1 = new PointF(Single.NaN, Single.NaN);
                intersection2 = new PointF(Single.NaN, Single.NaN);
                return 0;
            }
            else if (dist < Math.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new PointF(Single.NaN, Single.NaN);
                intersection2 = new PointF(Single.NaN, Single.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1)) 
            {
                // No solutions, the circles coincide.
                intersection1 = new PointF(Single.NaN, Single.NaN);
                intersection2 = new PointF(Single.NaN, Single.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                Double a  = (radius0 * radius0 - radius1 * radius1 + dist * dist) / (2 * dist);
                Double h  = Math.Sqrt(radius0 * radius0 - a * a);
                // Find P2.
                Double cx2 = cx0 + a * (cx1 - cx0) / dist;
                Double cy2 = cy0 + a * (cy1 - cy0) / dist;
                // Get the points P3.
                intersection1 = new PointF( (Single)(cx2 + h * (cy1 - cy0) / dist), (Single)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new PointF( (Single)(cx2 - h * (cy1 - cy0) / dist), (Single)(cy2 + h * (cx1 - cx0) / dist));
                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }
