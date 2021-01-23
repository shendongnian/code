    private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        Application curApp = Application.Current;
        var mainWnd = curApp.MainWindow as MainWindow;
        //ActualClass is a string variable that i set every time i change the content of the main frame in mainwindow
        if (mainWnd.ActualClass== "Page2.xaml")
        {
           //here i have to call a method of the Page2 class to launch an operation in Page2.cs only if the current page displayed in mainwindow frame is Page2.xaml
               var content = mainWnd._mainFrame.Content as Page2Class;
                if (content != null)
                {
                    content.Method();
                }
        }
    }
