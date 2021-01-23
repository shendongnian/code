    foreach (var item in MyList)
    {
        Uri uri = new Uri(item.url, UriKind.Absolute);
        HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
        request.BeginGetResponse((ar) =>
        {
            var response = request.EndGetResponse(ar);
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                using (var stream = response.GetResponseStream())
                {
                    var name = GetFileName(item.url);
                    if (localFile.FileExists(name))
                    {
                        localFile.DeleteFile(name);
                    }
                    using (IsolatedStorageFileStream fs = localFile.CreateFile(name))
                    {
                        stream.CopyTo(fs);
                    }
                }
            });
        }, null);
    }
