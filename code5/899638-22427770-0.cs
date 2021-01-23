    public class DiffLineBackgroundRenderer : IBackgroundRenderer
    {
        static Pen pen;
        static SolidColorBrush removedBackground;
        static SolidColorBrush addedBackground;
        static SolidColorBrush headerBackground;
        FileDiffView host;
        static DiffLineBackgroundRenderer()
        {
            removedBackground = new SolidColorBrush(Color.FromRgb(0xff, 0xdd, 0xdd)); removedBackground.Freeze();
            addedBackground = new SolidColorBrush(Color.FromRgb(0xdd, 0xff, 0xdd)); addedBackground.Freeze();
            headerBackground = new SolidColorBrush(Color.FromRgb(0xf8, 0xf8, 0xff)); headerBackground.Freeze();
            var blackBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0)); blackBrush.Freeze();
            pen = new Pen(blackBrush, 0.0);
        }
        public DiffLineBackgroundRenderer(FileDiffView host)
        {
            this.host = host;
        }
        public KnownLayer Layer 
        {
            get { return KnownLayer.Background; }
        }
        public void Draw(TextView textView, DrawingContext drawingContext)
        {
            foreach (var v in textView.VisualLines) 
            {
                var rc = BackgroundGeometryBuilder.GetRectsFromVisualSegment(textView, v, 0, 1000).First();
                // NB: This lookup to fetch the doc line number isn't great, we could
                // probably do it once then just increment.
                var linenum = v.FirstDocumentLine.LineNumber - 1;
                if (linenum >= host.ViewModel.Lines.Count) continue;
                var diffLine = host.ViewModel.Lines[linenum];
                if (diffLine.Style == DiffLineStyle.Context) continue;
                var brush = default(Brush);
                switch (diffLine.Style)
                {
                case DiffLineStyle.Header:
                    brush = headerBackground;
                    break;
                case DiffLineStyle.Added:
                    brush = addedBackground;
                    break;
                case DiffLineStyle.Deleted:
                    brush = removedBackground;
                    break;
                }
                drawingContext.DrawRectangle(brush, pen, 
                    new Rect(0, rc.Top, textView.ActualWidth, rc.Height));
            }
        }
    }
