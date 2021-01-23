     public class Pair
    {
        public Pair()
        {
        }
        public Pair(float first, float second)
        {
            this.First = first;
            this.Second = second;
        }
        public float First { get; set; }
        public float Second { get; set; }
    };
    public class ImageButton :  FrameworkElement
    {
        List<Pair> items;
        Boolean dragDown = false;
        bool dragVert = false;
        int dragSeg = -1;
        
        public ImageButton()  {
            items = new List<Pair>();
            items.Add(new Pair(0, 0));
            items.Add(new Pair(40, 40));
            items.Add(new Pair(60, 0));
            items.Add(new Pair(100, 20));
            items.Add(new Pair(115, 0));
            items.Add(new Pair(185, 20));
            items.Add(new Pair(215, 0));
            items.Add(new Pair(300, 0));
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            int seg;
            bool vert;
            if (getSegment(e.GetPosition(this).X, e.GetPosition(this).Y, out seg, out vert))
            {
                dragDown = true;
                dragSeg = seg;
                dragVert = vert;
                //We are dragging now
            }
            
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            dragDown = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            double basey = RenderSize.Height - 10;
            int seg;
            bool vert;
            if (!dragDown)
            {
                if (getSegment(e.GetPosition(this).X, e.GetPosition(this).Y, out seg, out vert))
                {
                    if (vert)
                    {
                        Cursor = Cursors.SizeWE;
                    }
                    else
                    {
                        Cursor = Cursors.SizeNS;
                    };
                }
                else
                {
                    Cursor = Cursors.No;
                }
            }
            else
            {
                //Must be dragging.
                if (dragVert)
                {
                    //This will change the X position of the segment...........
                    items[dragSeg].First = (int) e.GetPosition(this).X;
                    InvalidateVisual();
                }
                else
                {
                    items[dragSeg].Second = (int)(basey - ((int)e.GetPosition(this).Y));
                    //Change vertical
                    InvalidateVisual();
                }
            }
            base.OnMouseMove(e);
        }
        protected override void OnRender(DrawingContext dc)
        {
            Brush b = new SolidColorBrush(Color.FromRgb(40,40,40));
            dc.DrawRectangle(b, new Pen(b, 2), new Rect(0, 0, this.RenderSize.Width, RenderSize.Height));
            Pen p = new Pen(new SolidColorBrush(Color.FromRgb(240, 240, 240)), 2);
            double basey = RenderSize.Height - 10;
            for (int i = 0; i < items.Count-1; i++)
            {
                Brush br = new SolidColorBrush(Color.FromRgb(240, 40, 40));
                Rect t = new Rect(items[i].First,basey-items[i].Second, items[i+1].First-items[i].First,items[i].Second);
                dc.DrawRectangle(br, p, t);
            }
        }
        /// <summary>
        /// Returns if over a segment, and how.  
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool getSegment(double x, double y, out int index, out bool vert)
        {
            double basey = RenderSize.Height - 10;
            index = 0;
            vert = false;
            for (int i = 0; i < items.Count - 1; i++)
            {
                //Check for vertical section going up
                if ((x >= (items[i].First - 3)) && ( x <= (items[i].First + 3))) {
                    // x is hovering close to segment, check Y
                    if ((y < (basey)) && (y>=(basey-items[i].Second))) {
                        index = i;
                        vert = true;
                        return true;
                    }
                }
                //Check vertical going down.
                if ((x >= (items[i + 1].First - 3)) && (x <= (items[i + 1].First + 3)))
                {
                    if ((y < (basey)) && (y >= (basey - items[i].Second)))
                    {
                        index = i+1;
                        vert = true;
                        return true;
                    }
                }
                //In the middle section
                if ((x >= (items[i].First) && (x <= (items[i+1].First)))) {
                    //Check for close to line seg.
                    if ((y < (basey - items[i].Second + 3)) && (y > (basey - items[i].Second - 3)))
                    {
                        index = i;
                        vert = false;
                        return true;
                    }
                }
                
            }
            return false;
        }
    }
