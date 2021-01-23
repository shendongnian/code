	var dm =  (DownloadManager) GetSystemService (Context.DownloadService);
	string webUri = "http://somewhere/some.png";
	var dir =  new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/MyAppFolder/");
	if (!dir.Exists ())
		dir.Mkdirs ();
	var uri = Android.Net.Uri.FromFile (new Java.IO.File (dir.AbsolutePath+"/my.png"));
	var request = new  DownloadManager.Request (Android.Net.Uri.Parse (webUri));
	request.SetDestinationUri (uri);
	dm.Enqueue (request);
                 
