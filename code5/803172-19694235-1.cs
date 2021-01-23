    WebClient pdfDownloader = null;
    string LastFileName = ""; //To save the filename of the last created pdf
    private void StartPDFDownload()
    {
    	pdfDownloader = new WebClient(); //prevents that the OpenReadCompleted-Event is called multiple times
    	pdfDownloader.OpenReadCompleted += DownloadPDF; //Create an event handler
    	pdfDownloader.OpenReadAsync(new Uri("Your URL as string with HTTP://")); //Start to read the website
    }
    async void DownloadPDF(object sender, OpenReadCompletedEventArgs e)
    {
    	byte[] buffer = new byte[e.Result.Length]; //Gets the byte length of the pdf file
    	await e.Result.ReadAsync(buffer, 0, buffer.Length); //Waits until the rad is completed (Async doesn't block the GUI Thread)
    
    	using (IsolatedStorageFile storageFile = IsolatedStorageFile.GetUserStoreForApplication())
    	{
    		try
    		{
    			LastFileName = "tempPDF" + DateTime.Now.Ticks + ".pdf";
    			using (IsolatedStorageFileStream stream = storageFile.CreateFile(LastFileName))
    			{
    				await stream.WriteAsync(buffer, 0, buffer.Length);
    			}
    		}
    		catch (Exception ex)
    		{
    			MessageBox.Show(ex.Message + Environment.NewLine + ex.HResult,
    				ex.Source, MessageBoxButton.OK);
    			//Catch errors regarding the creation of file
    		}
    	}
    	OpenPDFFile();
    }
    private async void OpenPDFFile()
    {
    	StorageFolder ISFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
    	try
    	{
    		IStorageFile file = await ISFolder.GetFileAsync(LastFileName);
    		await Windows.System.Launcher.LaunchFileAsync(file);
                //http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj206987%28v=vs.105%29.aspx
    	}
    	catch (Exception ex)
    	{
    		//Catch unknown errors while getting the file
    		//or opening the app to display it
    	}
    }
