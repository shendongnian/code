    private async void button1_Click(object sender, EventArgs e)
    {
        await checkLink_async();  
        await checkLink_async();
		await checkLink_async();        
    }
    /// <summary>
    /// Check the availability of IP server by starting async read from input sensors.
    /// </summary>
    /// <returns>Nothing</returns> 
    public async Task checkLink_async()
    {
        string siteipURL = "http://localhost/ip9212/getio.php";
        // Send http query
        var client = new System.Net.WebClient();
        try
        {            
            Task t = client.DownloadDataTaskAsync(siteipURL);
			
            //tl.LogMessage("CheckLink_async", "http request was sent");
			
			await t;
			
			//tl.LogMessage("checkLink_DownloadCompleted", "http request was processed");
        }
        catch (System.Net.WebException e)
        {
           // tl.LogMessage("CheckLink_async", "error:" + e.Message);
        }
    }
	
