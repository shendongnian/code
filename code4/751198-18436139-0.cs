    class NonScalableTextBlock : System.Windows.Controls.TextBlock
    {
        public Transform RenderTransform
        {
            get 
            { 
                return base.RenderTransform; 
            }
            set 
            { 
                // do nothing
            }
        }
    }
