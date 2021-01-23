    private void OnUpdateDrawing(DrawingDto drawing)
        {
            Execute.OnUiThread(() =>
            {
                (Strokes as INotifyCollectionChanged).CollectionChanged -= StrokesOnCollectionChanged;
                var strokeCollection = new StrokeCollection();
                foreach (var deletedStroke in drawing.DeletedStrokes)
                {
                    Strokes.Erase(deletedStroke.Points.Select(x => new System.Windows.Point(x.X, x.Y)), new RectangleStylusShape(0.01, 0.01));
                }
                foreach (var newStroke in drawing.NewStrokes)
                {
                    var pointCollection = new StylusPointCollection();
                    foreach (var point in newStroke.Points)
                    {
                        pointCollection.Add(new StylusPoint(point.X, point.Y));
                    }
                    strokeCollection.Add(new Stroke(pointCollection));
                }
                Strokes.Add(strokeCollection);
               
                (Strokes as INotifyCollectionChanged).CollectionChanged += StrokesOnCollectionChanged;
            });
        }
