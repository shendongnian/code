    _dtBotonBuscarMouseClick =
                    new System.Windows.Threading.DispatcherTimer(
                    new TimeSpan(0, 0, 0, 0, 250),
                    System.Windows.Threading.DispatcherPriority.Background,
                    MouseClick_Tick,
                    System.Windows.Threading.Dispatcher.CurrentDispatcher);
                _dtMouseClick.Stop();
