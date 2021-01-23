    private IEnumerator SendGetRequest(string url, Action<string> callback, string _token = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            if (!string.IsNullOrEmpty(_token))
                www.SetRequestHeader("authorization", string.Format("Bearer {0}", _token));
            www.SendWebRequest();
            while (!www.isDone)
            {
                yield return false;
            }
            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
            }
            if (www.isDone)
            {
                callback(www.downloadHandler.text);
            }
        }
    }
