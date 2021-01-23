            protected override void OnContentRendered(EventArgs e)
            {
                base.OnContentRendered(e);
                MoveBottomRightEdgeOfWindowToMousePosition();
            }
    
            private void MoveBottomRightEdgeOfWindowToMousePosition()
            {
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var mouse = transform.Transform(GetMousePosition());
                Left = mouse.X - ActualWidth;
                Top = mouse.Y - ActualHeight;
            }
    
            public System.Windows.Point GetMousePosition()
            {
                System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
                return new System.Windows.Point(point.X, point.Y);
            }
