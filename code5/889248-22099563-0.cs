     public static class ContenPreviewMouseDownCommandBinding
        {
            public static readonly DependencyProperty CommandProperty =
                DependencyProperty.RegisterAttached("Command", typeof (ICommand), typeof (ContenPreviewMouseDownCommandBinding), 
                new PropertyMetadata(default(ICommand), HandleCommandChanged));
    
            private static void HandleCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var contentPresenter = d as ContentPresenter;
                if(contentPresenter!=null)
                {
                    contentPresenter.PreviewMouseDown += new MouseButtonEventHandler(contentPresenter_PreviewMouseDown);
                }
            }
    
            static void contentPresenter_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                var contentPresenter = sender as ContentPresenter;
                if(contentPresenter!=null)
                {
                    var command = GetCommand(contentPresenter);
                    command.Execute(e);
                }            
            }
    
            public static void SetCommand(ContentPresenter element, ICommand value)
            {
                element.SetValue(CommandProperty, value);
            }
    
            public static ICommand GetCommand(ContentPresenter element)
            {
                return (ICommand) element.GetValue(CommandProperty);
            }
        }
