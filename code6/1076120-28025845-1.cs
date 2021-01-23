      public class ReverseWrapPanel : WrapPanel
        {
            public new Orientation Orientation { get { return base.Orientation; } set { base.Orientation = value; ResetAll(); } }
    
            /// <summary>
            /// The opposite of the Orientation property.
            /// </summary>
            Orientation FlipDirection { get { return Orientation == Orientation.Horizontal ? Orientation.Vertical : Orientation.Horizontal; } }
    
            public ReverseWrapPanel()
            {
                Initialized += ReverseWrapPanel_Initialized;
            }
    
            void ReverseWrapPanel_Initialized(object sender, System.EventArgs e)
            {
                this.Mirror(FlipDirection);
            }
    
            protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
            {
                base.OnVisualChildrenChanged(visualAdded, visualRemoved);
    
                foreach (UIElement child in Children.OfType<UIElement>())
                {
                    child.Mirror(FlipDirection);
                }
            }
    
            void ResetAll()
            {
                this.Mirror(FlipDirection);
    
                foreach (UIElement child in Children.OfType<UIElement>())
                {
                    child.Mirror(FlipDirection);
                }
            }
        }
