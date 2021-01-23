    public class TestingMyControl : MyControl
    {
        public DrawingGroup Render()
        {
            var drawingGroup = new DrawingGroup();
            using (var drawingContext = drawingGroup.Open())
            {
                 base.OnRender(drawingContext);
            }
        }
    }
