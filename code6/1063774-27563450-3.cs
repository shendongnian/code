    public class MyCanvas : Canvas
    {
        protected override Size ArrangeOverride(Size finalSize)
        {
            var children = this.GetDescendantsOfType<ContentPresenter>();
            foreach (var item in children)
            {
                var data = item.Content as Data;
                if (data != null)
                {
                    Canvas.SetLeft(item, data.xIndex);
                    Canvas.SetTop(item, data.yIndex);
                }
            }
            return base.ArrangeOverride(finalSize);
        }
    }
