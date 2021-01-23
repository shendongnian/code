     public class GenericAdorner : Adorner
    {
        private readonly UIElement adorner;
        private readonly Point point;
        public GenericAdorner(UIElement targetElement, UIElement adorner, Point point) : base(targetElement)
        {
            this.adorner = adorner;
            if (adorner != null)
            {
                AddVisualChild(adorner);
            }
            this.point = point;
        }
        protected override int VisualChildrenCount
        {
            get { return adorner == null ? 0 : 1; }
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (adorner != null)
            {
                adorner.Arrange(new Rect(point, adorner.DesiredSize));
            }
            return finalSize;
        }
        protected override Visual GetVisualChild(int index)
        {
            if (index == 0 && adorner != null)
            {
                return adorner;
            }
            return base.GetVisualChild(index);
        }
    }
     public static void TryRemoveAdorner<T>(this UIElement element)
            where T:Adorner
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(element);
            if (layer != null)
                layer.RemoveAdorners<T>(element);
        }
        public static void RemoveAdorners<T>(this AdornerLayer layer, UIElement element)
            where T : Adorner
        {
            var adorners = layer.GetAdorners(element);
            if (adorners == null) return;
            for (int i = adorners.Length -1; i >= 0; i--)
            {
                if (adorners[i] is T)
                    layer.Remove(adorners[i]);
            }
        }
        public static void TryAddAdorner<T>(this UIElement element, Adorner adorner)
            where T: Adorner
        {
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(element);
            if (layer != null)
                try
                {
                    layer.Add(adorner);
                }
                catch (Exception) { }
        }
        public static bool HasAdorner<T>(this AdornerLayer layer, UIElement element) where T : Adorner
        {
            var adorners = layer.GetAdorners(element);
            if (adorners == null) return false;
            for (int i = adorners.Length - 1; i >= 0; i--)
            {
                if (adorners[i] is T)
                    return true;
            }
            return false;
        }
        public static void RemoveAdorners(this AdornerLayer layer, UIElement element)
        {
            var adorners = layer.GetAdorners(element);
            if (adorners == null) return;
            foreach (Adorner remove in adorners)
                layer.Remove(remove);
        }
