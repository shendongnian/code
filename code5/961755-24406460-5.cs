    string nextUrl = null;
       
    public void PageRetrievedCallback(RestResponse response)
    {
     	var rootObject = JsonConvert.DeserializeObject<RootObject> (response.Content);
        nextURL = rootObject.pagination.next_url;
     	
     	table.InvokeOnMainThread (() => {
                // Create list that contains newly attained JSON
                List<Datum> instagramData = rootObject.data;
                // Create dummy list for other values
                List<Datum> sloppy = null;
                ((TableSource<Datum>)table.Source).instaData.AddRange (instagramData);
                table.ReloadData ();
             });
    }
