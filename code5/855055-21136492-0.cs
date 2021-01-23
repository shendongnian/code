    public bool IsContentUrlExists(string url)
    {
          url = url.Trim().TrimEnd(new[]{'/'});
          return Context.Contents.Any(content => content.Url == url || content.Url == url + "/");
    }
