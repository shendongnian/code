     void CurrentChannel_ShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
               {
                   ToastPrompt prompt = new ToastPrompt()
                   {
                       TextOrientation = System.Windows.Controls.Orientation.Vertical,
                       Title = e.Collection["wp:Text1"],
                       Message = e.Collection["wp:Text2"],
                       ImageSource = new BitmapImage(new Uri(<image URI here>, UriKind.RelativeOrAbsolute))
                   };
                   prompt.Show();
               });
        }
