    class ChildWindow{
        public ChildWindow(MainWindow.RefreshInformationsDelegate callback){
            //Do work
            //Notify MainWindow that we are closing
            callback();
        }
    }
    class MainWindow{
        public static delegate void RefreshInformationsDelegate();
        private void LaunchBaloonProces(object sender, RoutedEventArgs e)
        {
            if (countBaloonProcess() < 5) {
                Application app = System.Windows.Application.Current;
                ClassLibrary1.Ballon b = new Ballon(new RefreshInformationsDelegate(refreshInformations));
                Thread unThread = new Thread(new ThreadStart(b.Go));
                unThread.Start();
                if (allPaused) unThread.Suspend();
                unThread.Name = "Ballon";
                processList.AddLast(unThread);
            } 
            else {
                informations.SetValue(TextBox.TextProperty, "Can't create more than 5 baloons");
            }
        }
    }
