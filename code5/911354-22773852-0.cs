        private void OpenOnce(Window win)
        {
            foreach (Window n in Application.Current.Windows)
            {
                if (n.GetType() == win.GetType())
                {
                    if (n.IsLoaded)
                    {
                        MessageBox.Show("The window is already open");
                        return;
                    }
                }
            }
            win.Show();
        }
