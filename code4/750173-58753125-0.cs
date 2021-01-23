        void OpenNewOrRestoreWindow<T>() where T : Window, new()
        {
            bool isWindowOpen = false;
            foreach (Window w in Application.Current.Windows)
            {
                if (w is T)
                {
                    isWindowOpen = true;
                    w.Activate();
                }
            }
            if (!isWindowOpen)
            {
                T newwindow = new T();
                newwindow.Show();
            }
        }
