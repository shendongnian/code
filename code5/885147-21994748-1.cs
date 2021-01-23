    else
    {
			DownloadImage(contentItem.WebPath, contentItem.FilePath).ContinueWith (t =>
				{
				    if (contentItem.FilePath == t.Result)
				    {
				        SetImage(_image, t.Result);
				    }
				});
    }
