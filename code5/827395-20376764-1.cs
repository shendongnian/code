    class BoundaryElement : FrameworkElement {
        public static readonly DependencyProperty CustomProperty =
            AttachedProperties.CustomProperty.AddOwner(typeof(BoundaryElement),
                new FrameworkPropertyMetadata() {Inherits = false});
    }
