    Alert _tempWindow;
    
    private void StatusChanges(Alarm m, EventArgs e)
    {
        //Compares two 32-bit signed integers for equality and, if they are equal, replaces one of the values.
            if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
            {
                newWindowThread = new Thread(new ThreadStart(() =>
                {
                    try
                    {   
                        // Create and show the Window
                        _tempWindow = new Alert();
                        _tempWindow.Close += OnTempClosed;
                        _tempWindow.Show();
    
                        System.Windows.Threading.Dispatcher.Run();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        running = 0;
                    }
    
                }));
    
                // Set the apartment state
                newWindowThread.SetApartmentState(ApartmentState.STA);
                // Make the thread a background thread
                newWindowThread.IsBackground = true;
                newWindowThread.Start();
            }
        }
        else
        {
            if (Interlocked.CompareExchange(ref running, 0, 1) == 1)
            {
                try
                {
                    _tempWindow.Dispatcher.BeginInvoke((Action)_tempWindow.Close);
                }
                catch (Exception)
                {
                    //throw;
                    MessageBox.Show("Todo esta ok");
                }
            }
            //running = 0;
        }
    }
    
    private void OnTempClosed(object sender, EventArgs e)
    {
        System.Windows.Threading.Dispatcher.FromThread(newWindowThread).InvokeShutdown();
    }
