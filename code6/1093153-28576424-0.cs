    protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
            {
                if (_group == null) //private field, hack so it only adding content once
                {
                    var grid = new StackPanel() { Orientation = Orientation.Vertical };
                    _group = new WarningBoxControl();
    
                    var content = Content as StackPanel;
                    if (content != null)
                    {
                        _group.DataContext = content.DataContext;
                        content.Children.Insert(0, _group);
                    }
                }
                
                base.OnRender(drawingContext);
            }
