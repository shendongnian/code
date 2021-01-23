    string imageName = "myImage.jpg";
    string imageUrl = "http://political-leader.vzons.com/ArvindKejriwal/images/icons/landing.png";
    
    public MainPage()
    {
    	InitializeComponent();
    	LoadImage();
    }
    
    private void LoadImage()
    {
    	BitmapImage bi = new BitmapImage();
    	using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    	{
    		//load image from Isolated Storage if it already exist
    		if (myIsolatedStorage.FileExists(imageName))
    		{
    			using (IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(imageName, FileMode.Open, FileAccess.Read))
    			{
    				bi.SetSource(fileStream);
    				imageBrushName.ImageSource = bi;
    			}
    		}
    		//else download image to Isolated Storage
    		else
    		{
    			WebClient wc = new WebClient();
                wc.OpenReadCompleted += new OpenReadCompletedEventHandler(DownloadCompleted);
                wc.OpenReadAsync(new Uri(imageUrl, UriKind.Absolute), wc);
    		}
    	}
    }
    
    private void DownloadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
    	if (e.Error == null && !e.Cancelled)
    	{
    		try
    		{
    			using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
    			{
    				IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(imageName);
    
    				BitmapImage bitmap = new BitmapImage();
    				bitmap.SetSource(e.Result);
    				WriteableBitmap wb = new WriteableBitmap(bitmap);
    
    				// Encode WriteableBitmap object to a JPEG stream.
    				Extensions.SaveJpeg(wb, fileStream, wb.PixelWidth, wb.PixelHeight, 0, 85);
    				fileStream.Close();
    			}
    			//after image saved to Iso storage, call LoadImage method again
    			//so the method will set imageBrush's ImageSource to image in Iso storage
    			LoadImage();
    		}
    		catch (Exception ex)
    		{
    			//Exception handle appropriately for your app  
    		}
    	}
    	else
    	{
    		//Either cancelled or error handle appropriately for your app  
    	}
    }
