    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    
    namespace DataGrid
    {
        internal class FillHandleAdorner : Adorner
        {
            const int SIZE = 5;
    
            Rect rect;
    
            readonly Thumb thumb;
    
            readonly VisualCollection visualChildren;
    
            Point mousePosition;
    
            System.Windows.Controls.DataGrid dataGrid;
    
            public Rect Rect
            {
                get { return rect; }
                set
                {
                    rect = value;
                    UpdateThumbPos(rect);
                    mousePosition = rect.BottomRight;
                    InvalidateVisual();
                }
            }
    
            public FillHandleAdorner(UIElement adornedElement, Rect rect)
                : base(adornedElement)
            {
                dataGrid = (System.Windows.Controls.DataGrid)adornedElement;
                Rect = rect;
    
                visualChildren = new VisualCollection(this);
                var border = new FrameworkElementFactory(typeof(Border));
                border.SetValue(Border.BackgroundProperty, Brushes.Black);
                thumb = new Thumb
                {
                    Cursor = Cursors.Cross,
                    Background = new SolidColorBrush(Colors.Black),
                    Height = SIZE,
                    Template = new ControlTemplate(typeof(Thumb)) { VisualTree = border },
                    Width = SIZE
                };
                visualChildren.Add(thumb);
    
                UpdateThumbPos(rect);
    
                thumb.DragDelta += thumb_DragDelta;
            }
    
            void UpdateThumbPos(Rect rect)
            {
                if (thumb == null) return;
                mousePosition = rect.BottomRight;
                mousePosition.Offset(-SIZE/2 - 1, -SIZE/2 - 1);
                thumb.Arrange(new Rect(mousePosition, new Size(SIZE, SIZE)));
            }
    
            void thumb_DragDelta(object sender, DragDeltaEventArgs e)
            {
                mousePosition.Offset(e.HorizontalChange, e.VerticalChange);
                IInputElement inputElt = dataGrid.InputHitTest(mousePosition);
                var tb = inputElt as TextBlock;
                if (tb == null) return;
                Point bottomRight = dataGrid.PointFromScreen(tb.PointToScreen(new Point(tb.ActualWidth + 1, tb.ActualHeight + 1)));
                Rect = new Rect(rect.TopLeft, bottomRight);
            }
    
            protected override int VisualChildrenCount
            {
                get { return visualChildren.Count; }
            }
    
            protected override Visual GetVisualChild(int index)
            {
                return visualChildren[index];
            }
    
            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);
    
                var blackSolidBrush = new SolidColorBrush(Colors.Black);
                var pen = new Pen(blackSolidBrush, 3);
                pen.Freeze();
                double halfPenWidth = pen.Thickness / 2;
    
                Rect rangeBorderRect = rect;
                rangeBorderRect.Offset(-1, -1);
    
                GuidelineSet guidelines = new GuidelineSet();
                guidelines.GuidelinesX.Add(rangeBorderRect.Left + halfPenWidth);
                guidelines.GuidelinesX.Add(rangeBorderRect.Right + halfPenWidth);
                guidelines.GuidelinesY.Add(rangeBorderRect.Top + halfPenWidth);
                guidelines.GuidelinesY.Add(rangeBorderRect.Bottom + halfPenWidth);
    
                Point p1 = rangeBorderRect.BottomRight;
                p1.Offset(0, -4);
                guidelines.GuidelinesY.Add(p1.Y + halfPenWidth);
    
                Point p2 = rangeBorderRect.BottomRight;
                p2.Offset(-4, 0);
                guidelines.GuidelinesX.Add(p2.X + halfPenWidth);
    
                drawingContext.PushGuidelineSet(guidelines);
    
                var geometry = new StreamGeometry();
                using (StreamGeometryContext ctx = geometry.Open())
                {
                    ctx.BeginFigure(p1, true, false);
                    ctx.LineTo(rangeBorderRect.TopRight, true, false);
                    ctx.LineTo(rangeBorderRect.TopLeft, true, false);
                    ctx.LineTo(rangeBorderRect.BottomLeft, true, false);
                    ctx.LineTo(p2, true, false);
                }
                geometry.Freeze();
                drawingContext.DrawGeometry(null, pen, geometry);
    
                drawingContext.Pop();
            }
        }
    }
