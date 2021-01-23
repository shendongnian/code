    //note the use of the the slightly older ContinueWith
    public Task<Bitmap> DownloadBitmap(/* whatever your params were */)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        //add the rest of the data/params or anything else you need then...
        // await the asynchronous request.
        return request.GetResponseAsync().ContinueWith((antecedent) => {
            HttpWebResponse myWebResponse = (HttpWebResponse)antencedent.Result;
            Stream responseStream = myWebResponse.GetResponseStream();
            return new Bitmap(responseStream);
        });
    }
