    //callback is used to handle server response
    private IEnumerator SendPostRequest(string url, List<IMultipartFormSection> data, 
    Action<string> callback, string _token = null)
    {
        using (UnityWebRequest www = UnityWebRequest.Post(url, data))
        {
            //Set auth token if available
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
