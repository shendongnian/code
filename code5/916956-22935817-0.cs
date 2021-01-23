            if (_element.Dispatcher.CheckAccess())
            {
                new Action(delegate()
                {
                    brush.set_image_brush(wb);
                
                }));
            }
            else
            {
                _element.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background,
                new Action(delegate()
                {
                    brush.set_image_brush(wb);
                }));
            }
