	private void RequestFriendsCallback(IGraphResult result)
	{
		if (!string.IsNullOrEmpty(result.RawResult))
		{
			var resultDictionary = result.ResultDictionary;
			if (resultDictionary.ContainsKey("data"))
			{
				var dataArray = (List<object>)resultDictionary["data"];//2.1.4
				var dic = dataArray.Select(x => x as Dictionary<string, object>).ToArray();
				foreach (var item in dic)
				{
					string id = (string)item["id"];
					var url = item.Where(x => x.Key == "picture").SelectMany(x => x.Value as Dictionary<string, object>).Where(x => x.Key == "data").SelectMany(x => x.Value as Dictionary<string, object>).Where(i => i.Key == "url").First().Value;
                    FriendData friend = Friends.Where(x => x.FacebookID == id).FirstOrDefault();
					if (friend != null)
						GetPictureByURL("" + url, friend);
				}
			}
			if (!string.IsNullOrEmpty(result.Error))
			{
				Debug.Log(result.Error);
			}
		}
	}
