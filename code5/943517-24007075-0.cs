       <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
            <Image Name="img"></Image>
            <Button Name="btn" Click="Btn_OnClick"></Button>
    
        </Grid>
 
    private async void Btn_OnClick(object sender, RoutedEventArgs e)
            {
                var file = await Windows.Storage.KnownFolders.PicturesLibrary.GetFileAsync("images.jpg");
                var fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(fileStream);
                img.Source = image;
                
            }
