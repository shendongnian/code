        public override Style SelectStyle(object item, DependencyObject container) {
            var containerElement = (FrameworkElement)container;
            var style = containerElement.TryFindResource(item.GetType()) as Style;
            if (style != null) {
                return style;
            }
            return base.SelectStyle(item, container);
        }
