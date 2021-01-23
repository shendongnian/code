    public async Task<int> UploadPicturesAsync(List<Image> imageList, 
         IProgress<int[]> progress)
    {
          int totalCount = imageList.Count;
          var progressCount = Enumerable.Repeat(0, totalCount).ToArray(); 
          return Task.WhenAll( imageList.map( (image, index) =>                   
            UploadAndProcessAsync(image, (percent) => { 
              progressCount[index] = percent;
              progress?.Report(progressCount);  
            });              
          ));
    }
    private async void Start_Button_Click(object sender, RoutedEventArgs e)
    {
        int uploads=await UploadPicturesAsync(GenerateTestImages(),
            new Progress<int[]>(percents => ... do something ...));
    }
