    class CompactFlow : LayoutEngine
    {
        private static CompactFlow instance;
        public static CompactFlow Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompactFlow();
                }
                return instance;
            }
        }
        public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
        {
            var cont = container as Control;
            if (cont != null)
                return LayoutCore(cont);
            else
                return base.Layout(container, layoutEventArgs);
        }
        private bool LayoutCore(Control container)
        {
            List<Rectangle> emptyTiles = new List<Rectangle>();
            emptyTiles.Add(new Rectangle(Point.Empty, container.Size));
            for (int i = 0; i < container.Controls.Count; i++)
            {
                var control = container.Controls[i];
                int j = 0;
                var tile = GetNextEmptyTile(emptyTiles, j++);
                //We don't know the location of the control yet, so we are only interested in size for this comparison
                while (!IsBigger(tile.Size, control.Size))
                {
                    tile = GetNextEmptyTile(emptyTiles, j++);
                    if (tile == Rectangle.Empty)
                    {
                        //?! Out of space...
                        break;
                    }
                }
                PlaceControl(emptyTiles, tile, control);
            }
            return true;
        }
        private void PlaceControl(List<Rectangle> emptyTiles, Rectangle tile, Control control)
        {
            //Place the control and work out how much space we have used
            control.Left = tile.Left + control.Margin.Left;
            control.Top = tile.Top + control.Margin.Top;
            var usedArea = GetUsedSpace(control);
            //When we place place the control, split the empty space it went into used/empty space
            //Add the Empty space back the list of empty tiles
            SplitTile(emptyTiles, tile, usedArea);
            //At this point the empty tiles over lap and the new control may intersect with a previously empty tile, that tile also needs splitting.
            for (int i = emptyTiles.Count - 1; i >= 0; i--)
            {
                var tileCheck = emptyTiles[i];
                if (tileCheck.IntersectsWith(usedArea))
                {
                    SplitTile(emptyTiles, tileCheck, usedArea);
                }
            }
            //Now we're left with a bit of a mess of emptyTiles, They might eventually get cleaned up but we'll run a "quick" check here to see if any tile
            //completely contains another, this will speed up future searches for empty tiles.
            //We could extend this further to merge to empty tiles next to each other with have the same height or width
            for (int i = emptyTiles.Count - 1; i >= 0; i--)
            {
                var tile1 = emptyTiles[i];
                for (int j = emptyTiles.Count - 1; j >= 0; j--)
                {
                    if (i != j)
                    {
                        var tile2 = emptyTiles[j];
                        if (tile1.Contains(tile2))
                        {
                            emptyTiles.Remove(tile2);
                            if (j < i)
                                i--;
                        }
                    }
                }
            }
            //The final trick is to sort the empty spaces, by y first then by x, This essentially determines the flow direction
            emptyTiles.Sort(new Comparison<Rectangle>((r1, r2) =>
            {
                if (r1.Y == r2.Y)
                {
                    return r1.X.CompareTo(r2.X);
                }
                return r1.Y.CompareTo(r2.Y);
            }));
        }
        private static Rectangle GetUsedSpace(Control control)
        {
            var usedSpace = control.Size;
            usedSpace.Width += control.Margin.Horizontal;
            usedSpace.Height += control.Margin.Vertical;
            var usedLocation = control.Location;
            usedLocation.X -= control.Margin.Left;
            usedLocation.Y -= control.Margin.Top;
            var usedArea = new Rectangle(usedLocation, usedSpace);
            return usedArea;
        }
        private static void SplitTile(List<Rectangle> emptyTiles, Rectangle tile, Rectangle usedArea)
        {
            var controlWidth = usedArea.Width;
            var controlHeight = usedArea.Height;
            //if the empty space is wider than the new space then make 2 new empty spaces either side of the used space,
            //the same height as the original empty space.
            if (tile.Width > controlWidth)
            {
                var newTile1 = new Rectangle(tile.Left, tile.Top, usedArea.Left - tile.Left, tile.Height);
                //If the used space was up against the edge than the new space wont be viable
                if (newTile1.Width > 0)
                {
                    emptyTiles.Add(newTile1);
                }
                var newTile2 = new Rectangle(usedArea.Right, tile.Top, tile.Right - usedArea.Right, tile.Height);
                if (newTile2.Width > 0)
                {
                    emptyTiles.Add(newTile2);
                }
            }
            if (tile.Height > controlHeight)
            {
                var newTile1 = new Rectangle(tile.Left, tile.Top, tile.Width, usedArea.Top - tile.Top);
                if (newTile1.Height > 0)
                {
                    emptyTiles.Add(newTile1);
                }
                var newTile2 = new Rectangle(tile.Left, usedArea.Bottom, tile.Width, tile.Bottom - usedArea.Bottom);
                if (newTile2.Height > 0)
                {
                    emptyTiles.Add(newTile2);
                }
            }
            //Remove the original as it now contains used space.
            emptyTiles.Remove(tile);
        }
        private bool IsBigger(Size size1, Size size2)
        {
            return (size1.Width >= size2.Width && size1.Height >= size2.Height);
        }
        private Rectangle GetNextEmptyTile(List<Rectangle> emptyTiles, int j)
        {
            if (j < emptyTiles.Count)
                return emptyTiles[j];
            else
                return Rectangle.Empty;
        }
    }
