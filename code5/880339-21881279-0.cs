    WebClient webClientImg = new WebClient();
    webClientImg.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
    webClientImg.OpenReadAsync(new Uri("http://delisle.saskatooncatholic.ca/sites/delisle.saskatooncatholic.ca/files/sample-1.jpg", UriKind.Absolute));
        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            isSpaceAvailable = IsSpaceIsAvailable(e.Result.Length);
            if (isSpaceAvailable)
            {
                SaveToJpeg(e.Result);
            }
            else
            {
                MessageBox.Show("You are running low on storage space on your phone. Hence the image will be loaded from the internet and not saved on the phone.", "Warning", MessageBoxButton.OK);
            }
        }
