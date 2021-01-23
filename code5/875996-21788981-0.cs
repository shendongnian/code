                        if (app == null)
                        {
                            Thread thread = new Thread(new ThreadStart(() =>
                                {
                                    app = new System.Windows.Application { ShutdownMode = ShutdownMode.OnExplicitShutdown };
                                    autoResetEvent.Set();
                                    app.Run();
                                }));
                            thread.SetApartmentState(ApartmentState.STA);
                            thread.Start();
                        }
                        else 
                        {
                            autoResetEvent.Set();
                        }
                        autoResetEvent.WaitOne(); //wait until app has been initialized on the other thread
                        app.Dispatcher.Invoke((Action)(() => { new MainWindow(graph).Show(); }));                       
                        }
