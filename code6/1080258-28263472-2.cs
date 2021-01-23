     public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            Messenger.Default.Register<NotificationMessage>(this, (m) =>
            {
                switch (m.Notification)
                {
                    case "SaveFile":
                        var dlg = new SaveFileDialog();
                        if (dlg.ShowDialog() == true)
                        {
                            var filename = dlg.FileName;
                            Messenger.Default.Send<String>( filename,"FileSaved");
                        }
                        break;
                    case "WentWell":
                        MessageBox.Show("Everything went well Wohoo");
                        break;
                }
            });
        }
    }
