    public static void StaticMainWindowMethod(string incomingMessage)
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            if (activeWindow != null)
            {
                var mainWindow = activeWindow as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.InstanceMainWindowMethod(incomingMessage);
                }
            }
        }
        protected void InstanceMainWindowMethod(string passedFromStaticMessage)
        {
            this.MainTextBox.Text = passedFromStaticMessage;
        }
