    private static object _syncLock = new object();
    public void CloseMyWindow()
    {
        lock(_syncLock)
        {
            if (myWindow != null)
            {
                myWindow.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    myWindow.Close();
                    myWindow = null;
                }));
            }
        }
    }
    private void OpenMyWindow(int width, int height, int top)
    {
        lock(_syncLock)
        {
            myWindow = new MyView();
            myWindow.Closed += new EventHandler(MyWindow_Closed);
            myWindow.Width = width;
            myWindow.Height = height;
            myWindow.Top = top;
            myWindow.Left = 0;
            myWindow.ShowDialog();
        }
    }
