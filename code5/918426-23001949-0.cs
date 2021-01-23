            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
                if (frame == null) {
                    return; //?
                }
                var mainPage = frame.Content as MainPage;
                if (mainPage == null) {
                    return; //?
                }
                mainPage.updateImage(byteArray);
            });
