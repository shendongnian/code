    private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new HttpClient();
            var bytes = await client.GetByteArrayAsync(new Uri("http://transfer-talk.com/wp-content/uploads/Kaka-Real-Madrid.jpg"));
            StorageFile sf = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("test.jpg", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteBytesAsync(sf, bytes);
            //var imageFile = await imagePicker.PickSingleFileAsync();
            //if (imageFile != null)
            {
                await LockScreen.SetImageFileAsync(sf);
            }
        }
