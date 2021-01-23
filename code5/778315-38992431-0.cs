    double height = pictureBox1.ActualHeight;
            double width = pictureBox1.ActualWidth;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("image-url-goes-here");
            
            var webResponse = response.Content.ReadAsStreamAsync();
            randomStream = webResponse.Result.AsRandomAccessStream();
            randomStream.Seek(0);
            
            wb = wb.Crop(50, 50, 400, 400);
            wb = wb.Resize(10,10 ,         WriteableBitmapExtensions.Interpolation.NearestNeighbor);
            wb = WriteableBitmapExtensions.Convolute(wb,WriteableBitmapExtensions.KernelGaussianBlur5x5);
            
            pictureBox1.Source= wb;
            
 
