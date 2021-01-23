    private string DoMyPaths(List<string> paths, JToken token)
	{
		string s = paths[0];
		if (paths.Count > 1)
		{
			paths.RemoveAt(0);
			JToken result = token[s];
			return DoMyPaths(paths, result);
		}
		return token[s].ToString();
	}
