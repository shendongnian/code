	public class GetDemData
	{
		List<string> addresses = new List<string>();
		public void AddDataToBeCollected(string address)
		{
			adresses.Add(address);
		}
		public Task CollectData()
		{
                    var webclient = new WebClient();
                    var tasks = from address in addresses
                                select webclient.DownloadStringAsyncTask(address);
                    return Task.WhenAll(tasks.Select(
                                async (downloadTask) => 
                                {
                                     var result = await downloadTask;
                                     //Do somthing with result
                                }));
		}
	}
	public async Task<ActionResult> GetData()
	{
		var data = new GetDemData();
		// fill data with addresses
		await data.CollectData();
		return View();
	}
