        public override void OnApplyTemplate()
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Loaded,
                new Action(
                    () =>
                        {
                            var button = this.GetTemplateChild("bttn") as Button;
                            for (DependencyObject child = VisualTreeHelper.GetChild(button, 0);
                                 child != null;)
                            {
                                if (child is ContentPresenter)
                                {
                                    var parent = (ContentPresenter)child;
                                    var element = parent.ContentTemplate.FindName("txtBlock", parent) as TextBlock;
                                    if (element != null)
                                    {
                                        Console.WriteLine("Found it!");
                                        break;
                                    }
                                }
                                if (VisualTreeHelper.GetChildrenCount(child) > 0)
                                {
                                    child = VisualTreeHelper.GetChild(child, 0);
                                }
                            }
                        }));
           
            base.OnApplyTemplate();
        }
