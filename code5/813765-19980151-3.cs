    public async Task<int> UploadPicturesAsync(List<Image> imageList, 
         IProgress<int> progress)
    {
          int totalCount = imageList.Count;
          int processCount = await Task.Run<int>(() =>
          {
              int tempCount = 0;
              foreach (var image in imageList)
              {
                  //await the processing and uploading logic here
                  int processed = await UploadAndProcessAsync(image);
                  if (progress != null)
                  {
                      progress.Report((tempCount * 100 / totalCount));
                  }
                  tempCount++;
              }
              return tempCount;
          });
          return processCount;
    }
    private async void Start_Button_Click(object sender, RoutedEventArgs e)
    {
        int uploads=await UploadPicturesAsync(GenerateTestImages(),
            new Progress<int>(percent => progressBar1.Value = percent));
    }
