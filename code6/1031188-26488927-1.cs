    using System.Linq;
    using System.Windows;
    
    internal class Class1
    {
        public Class1()
        {
            var rect1 = new Int32Rect(10, 10, 10, 10);
            var rect2 = new Int32Rect(30, 30, 10, 10);
            var rect3 = new Int32Rect(50, 50, 10, 10);
            var rect4 = new Int32Rect(70, 70, 10, 10);
    
            var int32Rects = new[] { rect1, rect2, rect3, rect4 };
            var int32Rect = GetValue(int32Rects);
        }
    
        private static Int32Rect GetValue(Int32Rect[] int32Rects)
        {
            int xMin = int32Rects.Min(s => s.X);
            int yMin = int32Rects.Min(s => s.Y);
            int xMax = int32Rects.Max(s => s.X + s.Width);
            int yMax = int32Rects.Max(s => s.Y + s.Height);
            var int32Rect = new Int32Rect(xMin, yMin, xMax - xMin, yMax - yMin);
            return int32Rect;
        }
    }
