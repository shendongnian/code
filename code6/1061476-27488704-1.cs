        // Your painting class. Only contains X and Y but could easily be expanded
        // to contain color and size info as well as drawing object type.
        class MyPaintingObject
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        // The class-level collection of painting objects to repaint with each invalidate call
        private List<MyPaintingObject> _paintingObjects = new List<MyPaintingObject>();
        // The UI which adds a new drawing object and calls invalidate
        private void button1_Click(object sender, EventArgs e)
        {
            // Hardcoded values 10 & 15 - replace with user-entered data
            _paintingObjects.Add(new MyPaintingObject{X=10, Y=15});
            panel1.Invalidate();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // loop through List<> and paint each object
            foreach (var mpo in _paintingObjects)
                e.Graphics.FillEllipse(Brushes.Red, mpo.X, mpo.Y, 20, 20);
        }
