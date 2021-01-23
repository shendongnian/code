      private void OpenView(Type newView, Type closeType)
            {
    
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.GetType() == closeType)
                    {
                        item.Close();
                    }
                }
    
                if (typeof(Window).IsAssignableFrom(newView))
                {
                    Window window = (Window)Activator.CreateInstance(newView);
                    window.Show();
                }
            }
