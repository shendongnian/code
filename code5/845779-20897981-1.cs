    void listBox_Loaded(object sender, RoutedEventArgs e)
            {
               
                FrameworkElement element = (FrameworkElement)sender;
                element.Loaded -= LstImage_Loaded;
                scrollViewer = FindChildOfType<ScrollViewer>(element);
                if (scrollViewer == null)
                {
                    throw new InvalidOperationException("ScrollViewer not found.");
                }
    
                Binding binding = new Binding();
                binding.Source = scrollViewer;
                binding.Path = new PropertyPath("VerticalOffset");
                binding.Mode = BindingMode.OneWay;
                this.SetBinding(ListVerticalOffsetProperty, binding);
            }
