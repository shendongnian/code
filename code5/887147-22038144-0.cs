    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            DefaultStyleKey = typeof (MyTextBox);
        }
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
             Console.WriteLine("OnRender");
             //base.OnRender(drawingContext);
             Rect bounds = new Rect(0, 0, 100, 100);
             Brush brush = new SolidColorBrush(Colors.Yellow);
             drawingContext.DrawRectangle(brush, null, bounds);
        }
    }
