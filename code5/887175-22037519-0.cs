            bool backContact = chkContacts.IsChecked.Value;
            bool backImages = chkImages.IsChecked.Value;
            Task.Factory.StartNew(() =>
                        {
                            if (backContact) {
                                Dispatcher.BeginInvoke(() =>
                                {
                                    SystemTray.ProgressIndicator.Text = "Searching contacts...";
                                });
                                UploadContacts;
                            });
                        }).ContinueWith(() =>
                            {
                                if (backImages) {
                                    Dispatcher.BeginInvoke(() =>
                                {
                                    SystemTray.ProgressIndicator.Text = "Compressing images...";
                                });
                                UploadImages;
                                }
                            }
