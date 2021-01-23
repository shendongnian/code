    protected override void OnMouseUp(MouseEventArgs e)
            {
                if (e.Y < 0)
                {
                    Top = 0;
                }
    
                base.OnMouseUp(e);
            }
    // This is required for OS like Vista and above 
            protected override void OnResizeEnd(EventArgs e)
            {
                if (Top < 0)
                {
                    Top = 0;
                }
                base.OnResizeEnd(e);
            }
