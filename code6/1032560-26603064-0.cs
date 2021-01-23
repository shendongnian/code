    public void Download (string string url)
    {
        StartCoroutine (Download_Coroutine (url));
    }
    IEnumerator Download_Coroutine (string url)
    {
        using (WWW www = WWW.LoadFromCacheOrDownload (bundleUrl, CurrentVersion))
        {
            while (!www.isDone) {
                yield return null;
                // optionally report www.progress to callback
            }
            if (string.IsNullOrEmpty (www.error)) {
                // s. doc for more options to get the content
                AssetBundle bundle = www.assetBundle;
                if (bundle != null) {
                    // do something
                }
            }
        }
    }
