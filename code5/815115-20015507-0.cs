        List<Tuple<Image, PointF>> Tiles = new List<Tuple<Image, PointF>>();
        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentTile != null)
            {
                float x1 = CommonUtils.GetClosestXTile(e.X);
                float y1 = CommonUtils.GetClosestYTile(e.Y);
                Tiles.Add(new Tuple<Image, PointF>(currentTile, new PointF(x1, y1)));
                canvas.Refresh();
                me.AddTile((int)currX, (int)currY, (int)x1, (int)y1, "C:\\DemoAssets\\tileb.png");
            }
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Tuple<Image, PointF> tile in Tiles)
            {
                e.Graphics.DrawImage(tile.Item1, tile.Item2);
            }
        }
